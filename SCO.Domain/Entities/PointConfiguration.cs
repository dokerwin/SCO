using SCO.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCO.Domain.Entities
{
    public class PointConfiguration : EntityBase<Guid>
    {
        public string LanguageId { get; set; }
        public string Currency { get; set; }

    }
}
