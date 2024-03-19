
namespace ImpuestosInternosBackEnd.Infrastructure.Persistence.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IComprobantesFiscalesRepository ComprobantesFiscales { get; }
        IContribuyentesRepository Contribuyentes { get; }
    }
}
