namespace SCO.ProductService.Application.Common.Interfaces.Persistance;

public interface IUnitOfWork : IDisposable
{
    ICategoryRepository          Categories { get; }
    IProductOwnerRepository      ProductOwners { get; }
    IProductRepository           Products { get; }
    ITaxRepository               Taxs { get; }

    Task CompleteAsync();
}

