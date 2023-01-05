using SCO.Identity.Domain.Entities.Employees;

namespace SCO.Identity.Application.Common.Interfaces.Persistance;

public interface ICashierRepository : IRepository<Cashier> 
{
    Task<Cashier> FindByEmailAsync(string email);
    Task<Cashier> GetActualCashier();
}
