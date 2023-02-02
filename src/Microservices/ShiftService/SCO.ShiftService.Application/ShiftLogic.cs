using Microsoft.Extensions.Logging;
using SCO.ShiftService.Application.Common.Interfaces.Persistance;
using SCO.ShiftService.Application.Handlers;
using SCO.ShiftService.Domain;

namespace SCO.ShiftService.Application;
public class ShiftLogic : IShiftLogic
{

    private readonly ILogger<ActualShiftInfoQueryHandler> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public ShiftLogic(IUnitOfWork unitOfWork, ILogger<ActualShiftInfoQueryHandler> logger )
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public Task EndShift()
    {
        throw new NotImplementedException();
    }

    public async Task StartShift(Guid cashierId)
    {
        await _unitOfWork.Shifts.Add(new Domain.Entities.Shift()
        {
            Id = Guid.NewGuid(),
            StartedOn = DateTime.UtcNow,
            CashierId = cashierId

        });
        await _unitOfWork.CompleteAsync();
    }
}