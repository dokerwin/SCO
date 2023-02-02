using AutoMapper;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using SCO.Contracts.Identity;
using SCO.Contracts.Requests.Identity;
using SCO.Contracts.Responses.Identity;
using SCO.Contracts.Responses.Shift;
using SCO.ShiftService.Application.Commands;
using SCO.ShiftService.Domain;

namespace SCO.ShiftService.Application.Handlers;


public class StartShiftCommandHandler : IRequestHandler<StartShiftCommand, StartShiftResponse>
{
    private readonly IBusControl _busControl;
    private readonly IMapper _mapper;
    private readonly IShiftLogic _shiftLogic;
    private readonly ILogger<StartShiftCommandHandler> _logger;

    public StartShiftCommandHandler(IMapper mapper,
        IShiftLogic shiftLogic,
        ILogger<StartShiftCommandHandler> logger,
        IBusControl busControl)
    {
        _mapper = mapper;
        _shiftLogic = shiftLogic;
        _logger = logger;
        _busControl = busControl;
    }

    public async Task<StartShiftResponse> Handle(StartShiftCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var identityLoginClient = _busControl.CreateRequestClient<LoginRequest>(TimeSpan.FromSeconds(180));

            var loginResponse = await identityLoginClient.GetResponse<AuthenticatedUserResponse>(new LoginRequest(request.Credential.Email, request.Credential.Password));

            if (loginResponse is not null && !string.IsNullOrEmpty(loginResponse.Message.AccessToken))
            {
                var identityCashierInfoClient = _busControl.CreateRequestClient<ActualCashierInfoRequest>(TimeSpan.FromSeconds(180));

                var cashierInfo = await identityCashierInfoClient.GetResponse<ActualCashierInfoResponse>(new ActualCashierInfoRequest());

                if (cashierInfo != null)
                {
                   await _shiftLogic.StartShift(cashierInfo.Message.CashierInfoDto.Id);
                   return await Task.FromResult(new StartShiftResponse("Success"));
                }
            }
            
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }

        return await Task.FromResult(new StartShiftResponse("Denied"));
    }
}
