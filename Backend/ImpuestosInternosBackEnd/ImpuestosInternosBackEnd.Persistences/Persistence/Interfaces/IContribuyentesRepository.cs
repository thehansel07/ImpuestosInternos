using ImpuestosInternosBackEnd.Domain.Entities;

namespace ImpuestosInternosBackEnd.Infrastructure.Persistence.Interfaces
{
    public interface IContribuyentesRepository
    {
        Task<bool> RegisterContribuyente(Contribuyente entity);
        Task<List<Contribuyente>> ListAllContribuyentes();
    }
}
