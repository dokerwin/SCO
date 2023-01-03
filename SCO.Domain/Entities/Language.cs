using SCO.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCO.Domain.Entities
{
    public class Language : EntityBase<Guid>
    { 
        public int LanguageId { get; set; }
        public string Name { get; set; }
    }
}
