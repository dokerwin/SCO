namespace SCO.PaymentService.Application.Common.Interfaces.Persistance;

public interface IUnitOfWork : IDisposable
{
    IPaymentRepository      Payments { get; }
    Task CompleteAsync();
}

