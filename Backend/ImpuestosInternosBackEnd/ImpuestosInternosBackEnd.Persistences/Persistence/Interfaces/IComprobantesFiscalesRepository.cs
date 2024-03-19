using ImpuestosInternosBackEnd.Domain.Entities;

namespace ImpuestosInternosBackEnd.Infrastructure.Persistence.Interfaces
{
    public interface IComprobantesFiscalesRepository
    {
        Task<List<ComprobantesFiscale>> SelectByCedulaOrRnc(string identifier);
        Task<bool> RegisterComprobantesFiscales(ComprobantesFiscale? entity);
        Task<IEnumerable<ComprobantesFiscale>> ListAllComprobantesFiscales();
    }
}
