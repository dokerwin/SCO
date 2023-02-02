using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SCO.Contracts.DTOs;
using SCO.Contracts.Responses.Shift;
using SCO.ShiftService.Application.Common.Interfaces.Persistance;
using SCO.ShiftService.Application.Queries;

namespace SCO.ShiftService.Application.Handlers;

public class ActualShiftInfoQueryHandler : IRequestHandler<ActualShiftInfoQuery, ActualShiftInfoResponse>
{
    private readonly IMapper _mapper;
    private readonly ILogger<ActualShiftInfoQueryHandler> _logger;
    private readonly IUnitOfWork _unitOfWork;
    public ActualShiftInfoQueryHandler(IMapper mapper,
        ILogger<ActualShiftInfoQueryHandler> logger,
        IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    public async Task<ActualShiftInfoResponse> Handle(ActualShiftInfoQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var shift = await _unitOfWork.Shifts.GetActualShiftInfo();

            var shiftInfoDto = _mapper.Map<ShiftInfoDto>(shift);
            return await Task.FromResult(new ActualShiftInfoResponse(shiftInfoDto));

        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }

        return await Task.FromResult(new ActualShiftInfoResponse(new ShiftInfoDto()));
    }
}

