using MediatR;
using SCO.Contracts.DTOs;
using SCO.Contracts.Responses.Shift;

namespace SCO.ShiftService.Application.Queries;

public record ActualShiftInfoQuery () : IRequest<ActualShiftInfoResponse>;
