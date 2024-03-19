using ImpuestosInternosBackEnd.Domain.Entities;
using ImpuestosInternosBackEnd.Infrastructure.Persistence.Contexts;
using ImpuestosInternosBackEnd.Infrastructure.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ImpuestosInternosBackEnd.Infrastructure.Persistence.Repository
{
    public class ComprobantesFiscalesRepository : IComprobantesFiscalesRepository
    {
        private readonly ImpuestoInternosContext _context;
        public ComprobantesFiscalesRepository(ImpuestoInternosContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ComprobantesFiscale>> ListAllComprobantesFiscales()
        {
            var listComprobantesFiscale = await _context.ComprobantesFiscales.ToListAsync();
            return listComprobantesFiscale;
        }

        public async Task<bool> RegisterComprobantesFiscales(ComprobantesFiscale? entity)
        {
            var currentEntity = new ComprobantesFiscale
            {
                RncCedula = entity!.RncCedula,
                Ncf = entity.Ncf,
                Monto = entity.Monto,
                Itbis18 = entity.Monto * 0.18m
            };

            await _context.ComprobantesFiscales.AddAsync(currentEntity);
            var recordsAffected = await _context.SaveChangesAsync();
            return recordsAffected > 0;
        }

        public async Task<List<ComprobantesFiscale>> SelectByCedulaOrRnc(string identifier)
        {
            var findByIdentifier = await _context.ComprobantesFiscales.Where(x=> 
                                                                       x.RncCedula.Equals(identifier))
                                                                       .ToListAsync();
            return findByIdentifier;
        }
    }
}
