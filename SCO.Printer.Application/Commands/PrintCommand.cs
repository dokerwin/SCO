using MediatR;
using SCO.Contracts.Responses.Printer;
using SCO.PrinterService.Application.DTOs;

public record PrintTicketCommand(TicketDto Ticket) : IRequest<PrinterResponse>;