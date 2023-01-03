namespace SCO.Identity.Application.Common.Interfaces.Persistance;

public interface IUnitOfWork : IDisposable
{ 
    IRoleRepository              Roles { get; }
    ICashierRepository           Cashiers { get; }

    Task CompleteAsync();
}

