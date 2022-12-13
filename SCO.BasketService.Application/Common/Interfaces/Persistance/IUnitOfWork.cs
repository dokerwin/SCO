namespace SCO.BasketService.Application.Common.Interfaces.Persistance;

public interface IUnitOfWork : IDisposable
{
    IOrderRepository Orders { get; }
  
    Task CompleteAsync();
}

