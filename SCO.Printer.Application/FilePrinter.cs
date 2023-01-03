using SCO.PrinterService.Application.DTOs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCO.PrinterService.Application
{
    public class FilePrinter : IPrinter
    {
        public bool IsPrinterEnabled { get; set; }

        public async Task<bool> PrintAsync(TicketDto ticketDto)
        {
            try
            {
                using StreamWriter file = new(string.Format("Ticket-{0}", ticketDto.Id), append: true);

                string ticket = string.Format("{0}\n{1}\n{2}\n{3}", ticketDto.Header, ticketDto.Body, ticketDto.Body, ticketDto.Footer );

                await file.WriteLineAsync(ticket);
            }
            catch(Exception ex)
            {

            }
            return true;
        }
    }
}
