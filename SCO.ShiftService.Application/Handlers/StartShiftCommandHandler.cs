using AutoMapper;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using SCO.Contracts.Identity;
using SCO.Contracts.Requests.Identity;
using SCO.Contracts.Responses.Identity;
using SCO.ShiftService.Application.Commands;
using SCO.ShiftService.Domain;

namespace SCO.ShiftService.Application.Handlers;


public class StartShiftCommandHandler : AsyncRequestHandler<StartShiftCommand>
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

    protected async override Task Handle(StartShiftCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var identityLoginClient = _busControl.CreateRequestClient<LoginRequest>(TimeSpan.FromSeconds(180));

            var loginResponse = await identityLoginClient.GetResponse<AuthenticatedUserResponse>(request);

            if (loginResponse is not null && !string.IsNullOrEmpty(loginResponse.Message.AccessToken))
            {
                var identityCashierInfoClient = _busControl.CreateRequestClient<CashierInfoRequest>(TimeSpan.FromSeconds(180));

                var cashierInfo = await identityCashierInfoClient.GetResponse<CashierInfoResponse>(request);

                if (cashierInfo != null)
                {
                   await _shiftLogic.StartShift(cashierInfo.Message.Id);   
                }
            }
            
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }
    }
}
