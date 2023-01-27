using MediatR;
using SCO.Contracts.Responses.Identity;

namespace SCO.Identity.Application.Authentication.Queries;

public record ActualCashierInfoQuery : IRequest<ActualCashierInfoResponse>;
