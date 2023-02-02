using AutoMapper;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using SCO.Contracts.DTOs;
using SCO.Contracts.Requests.Shift;
using SCO.Contracts.Responses.Shift;
using SCO.ShiftService.Application.Common.Interfaces.Persistance;
using SCO.ShiftService.Application.Queries;

namespace SCO.ShiftService.Application.MassTransit;

public class ActulShiftInfoConsumer : IConsumer<ActualShiftInfoRequest>
{
    private readonly ILogger<ActulShiftInfoConsumer> _logger;
    private readonly IMediator _mediator;
    public ActulShiftInfoConsumer(ILogger<ActulShiftInfoConsumer> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    public async Task Consume(ConsumeContext<ActualShiftInfoRequest> context)
    {
        try
        {
            var result = await _mediator.Send(new ActualShiftInfoQuery());
            await context.RespondAsync(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }
    }
}
