using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCO.Domain.Entities;

public class LogEvent : EventBase
{
    public string Description { get; set; }
}
