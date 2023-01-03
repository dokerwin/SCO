using SCO.PrinterService.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCO.PrinterService.Application;

public interface IPrinter
{
    bool IsPrinterEnabled { get; }
    Task<bool> PrintAsync(TicketDto ticketDto);
}
