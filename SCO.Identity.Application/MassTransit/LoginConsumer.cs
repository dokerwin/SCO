using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using SCO.Contracts.Identity;
using SCO.Contracts.Requests.Identity;
using SCO.Contracts.Responses;
using SCO.Identity.Application.Authentication.Commands.Login;

namespace SCO.Identity.Application.MassTransit;

public class LoginConsumer : IConsumer<LoginRequest>
{
    private readonly ILogger<LoginConsumer> _logger;
    private readonly IMediator _mediator;
    public LoginConsumer(ILogger<LoginConsumer> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    public async Task Consume(ConsumeContext<LoginRequest> context)
    {
        try
        {
            var result = await _mediator.Send(new LoginCommand(context.Message));

            await context.RespondAsync(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }
    }
}

