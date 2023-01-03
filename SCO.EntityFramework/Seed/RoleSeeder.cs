using SCO.Domain.Entities.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCO.EntityFramework.Seed
{
    public class RoleSeeder
    {
        public static IEnumerable<Role> GetRoles()
        {
            return new List<Role>()
            {
                new Role()
                {
                    Name = "User"
                },
                new Role()
                {
                    Name = "Manager"
                },
                new Role()
                {
                    Name = "Admin"
                }
            };
        }
    }
}
