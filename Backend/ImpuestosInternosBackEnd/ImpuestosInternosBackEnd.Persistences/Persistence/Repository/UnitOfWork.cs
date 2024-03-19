using ImpuestosInternosBackEnd.Infrastructure.Persistence.Contexts;
using ImpuestosInternosBackEnd.Infrastructure.Persistence.Interfaces;

namespace ImpuestosInternosBackEnd.Infrastructure.Persistence.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ImpuestoInternosContext _context;
        public IComprobantesFiscalesRepository ComprobantesFiscales { get; private set; }
        public IContribuyentesRepository Contribuyentes { get; private set; }

        public UnitOfWork(ImpuestoInternosContext context)
        {
            _context = context;
            ComprobantesFiscales = new ComprobantesFiscalesRepository(_context);
            Contribuyentes = new ContribuyentesRepository(_context);

        }
        public void Dispose()
        {
            _context.Dispose(); 
        }
    }
}
