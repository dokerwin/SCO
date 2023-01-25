using SCO.Identity.Domain.Entities.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCO.Identity.EntityFramework.Seed
{
    public class RoleSeeder
    {
        public static IEnumerable<Role> GetRoles()
        {
            return new List<Role>()
            {
                new Role()
                {
                    Id =  Guid.Parse("4b8052d8-eb97-488f-9a36-32cb61beac26"),
                    Name = "User"
                },
                new Role()
                {
                    Id = Guid.Parse("323452d8-eb97-488f-9a36-32cb61beac27"),
                    Name = "Manager"
                },
                new Role()
                {
                    Id = Guid.Parse("cfdbcf48-5ef9-4150-ad33-6615f2fdb4ad"),
                    Name = "Admin"
                }
            };
        }
    }
}
