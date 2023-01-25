using AutoMapper;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using SCO.Contracts.Identity;
using SCO.Contracts.Requests.Identity;
using SCO.Contracts.Responses.Identity;
using SCO.ShiftService.Application.Commands;
using SCO.ShiftService.Application.Common.Interfaces.Persistance;
using SCO.ShiftService.Application.Exceptions;
using SCO.ShiftService.Domain;

namespace SCO.ShiftService.Application.Handlers;


public class EndShiftCommandHandler : AsyncRequestHandler<EndShiftCommand>
{
    private readonly IBusControl _busControl;
    private readonly IMapper _mapper;
    private readonly IShiftLogic _shiftLogic;
    private readonly ILogger<EndShiftCommand> _logger;
    private readonly IUnitOfWork _unitOfWork;
    public EndShiftCommandHandler(IMapper mapper,
        IShiftLogic shiftLogic,
        ILogger<EndShiftCommand> logger,
        IBusControl busControl,
        IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _shiftLogic = shiftLogic;
        _logger = logger;
        _busControl = busControl;
        _unitOfWork = unitOfWork;
    }

    protected async override Task Handle(EndShiftCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var identityLoginClient = _busControl.CreateRequestClient<LoginRequest>(TimeSpan.FromSeconds(180));

            var loginResponse = await identityLoginClient.GetResponse<AuthenticatedUserResponse>(request);

            if (loginResponse is not null && !string.IsNullOrEmpty(loginResponse.Message.AccessToken))
            {
                var identityCashierInfoClient = _busControl.CreateRequestClient<CashierInfoRequest>(TimeSpan.FromSeconds(180));

                var cashierInfo = await identityCashierInfoClient.GetResponse<CashierInfoResponse>(request);

                var shiftInfo = await _unitOfWork.Shifts.GetActualShiftInfo(); 

                if (cashierInfo != null && shiftInfo != null && ( 
                    shiftInfo.CashierId == cashierInfo.Message.Id ||
                    cashierInfo.Message.Role == "Administrator"))
                {
                    await _shiftLogic.EndShift();
                }
                else
                {
                    throw new InvalidCredentialException("You have not permission to close the shift");
                }
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }
    }
}
