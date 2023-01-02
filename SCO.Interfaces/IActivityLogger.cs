using SCO.Domain.Entities;

namespace SCO.Interfaces;

public interface IActivityLogger
{
    IEnumerable<LogEvent> Get(long timestamp);
}
