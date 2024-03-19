using System.Reflection;
using ImpuestosInternosBackEnd.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ImpuestosInternosBackEnd.Infrastructure.Persistence.Contexts;

public partial class ImpuestoInternosContext : DbContext
{
    public ImpuestoInternosContext()
    {
    }
    public ImpuestoInternosContext(DbContextOptions<ImpuestoInternosContext> options)
        : base(options)
    {
    }
    public virtual DbSet<ComprobantesFiscale> ComprobantesFiscales { get; set; }
    public virtual DbSet<Contribuyente> Contribuyentes { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasAnnotation("Relational:Collection", "Modern_Spanish_CI_AS");
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
