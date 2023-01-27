using AutoMapper;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using SCO.Contracts.DTOs;
using SCO.Contracts.Requests.Identity;
using SCO.Contracts.Responses.Identity;
using SCO.Identity.Application.Authentication.Commands.Login;
using SCO.Identity.Application.Authentication.Queries;
using SCO.Identity.Application.Common.Interfaces.Persistance;

namespace SCO.Identity.Application.MassTransit;

public class ActualCashierInfoConsumer : IConsumer<ActualCashierInfoRequest>
{
    private readonly IMediator _mediator;
    private readonly ILogger<ActualCashierInfoConsumer> _logger;
    public ActualCashierInfoConsumer(ILogger<ActualCashierInfoConsumer> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    public async Task Consume(ConsumeContext<ActualCashierInfoRequest> context)
    {
        try
        {
            var result = await _mediator.Send(new ActualCashierInfoQuery());
            await context.RespondAsync(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }
    }
}

