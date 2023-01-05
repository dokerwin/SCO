using SCO.Identity.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCO.Identity.Domain;

public class RefreshToken : EntityBase<Guid>
{ 
    public string Token { get; set; }
    public Guid UserId { get; set; }
}
