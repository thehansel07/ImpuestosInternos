using ImpuestosInternosBackEnd.Domain.Entities;
using ImpuestosInternosBackEnd.Infrastructure.Persistence.Contexts;
using ImpuestosInternosBackEnd.Infrastructure.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ImpuestosInternosBackEnd.Infrastructure.Persistence.Repository
{
    public class ContribuyentesRepository : IContribuyentesRepository
    {
        private readonly ImpuestoInternosContext _context;
        public ContribuyentesRepository(ImpuestoInternosContext context)
        {
            _context = context;
        }
        public async Task<List<Contribuyente>> ListAllContribuyentes()
        {
            var listContribuyentes = await _context.Contribuyentes.ToListAsync();
            return listContribuyentes;
        }

        public async Task<bool> RegisterContribuyente(Contribuyente entity)
        {
            await _context.AddAsync(entity);
            var recordAffected = await _context.SaveChangesAsync();
            return recordAffected > 0;
        }
    }
}
