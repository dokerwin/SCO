using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SCO.Contracts.DTOs;
using SCO.Contracts.Responses.Identity;
using SCO.Identity.Application.Authentication.Queries;
using SCO.Identity.Application.Common.Interfaces.Persistance;

namespace SCO.Identity.Application.Authentication.Handlers;

public class ActualCashierInfoQueryHandler : IRequestHandler<ActualCashierInfoQuery, ActualCashierInfoResponse>
{
    private readonly ILogger<ActualCashierInfoQueryHandler> _logger;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public ActualCashierInfoQueryHandler(IMapper mapper, IUnitOfWork unitOfWork, ILogger<ActualCashierInfoQueryHandler> logger)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task<ActualCashierInfoResponse> Handle(ActualCashierInfoQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var actualCashierToken = await _unitOfWork.RefreshTokens.Last();

            var actualCashier = await _unitOfWork.Cashiers.GetById(actualCashierToken.UserId);

            var role = await _unitOfWork.Roles.GetById(actualCashier.RoleId);

            actualCashier.Role = role;

            var actualCashierInfoDto = _mapper.Map<CashierInfoDto>(actualCashier);
            return await Task.FromResult(new ActualCashierInfoResponse(actualCashierInfoDto));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }
        return await Task.FromResult(new ActualCashierInfoResponse(new CashierInfoDto()
        {
          Id = Guid.Empty,
          Name  = string.Empty,
          Role =  string.Empty
        }));
    }
}
