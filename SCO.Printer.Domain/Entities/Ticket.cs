using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCO.PrinterService.Domain.Entities
{
    public class Ticket
    {
        public Header Header { get; set; }
        public Body   Body { get; set; }
        public EFTSlip EFTSlip { get; set; }
        public Footer Footer { get;set; }

    }
}
