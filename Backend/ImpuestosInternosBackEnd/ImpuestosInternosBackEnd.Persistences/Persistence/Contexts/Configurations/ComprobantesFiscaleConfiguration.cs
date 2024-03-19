using ImpuestosInternosBackEnd.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpuestosInternosBackEnd.Infrastructure.Persistence.Contexts.Configurations
{
    public class ComprobantesFiscaleConfiguration : IEntityTypeConfiguration<ComprobantesFiscale>
    {
        public void Configure(EntityTypeBuilder<ComprobantesFiscale> entity)
        {
            entity.HasKey(e => e.IdComprobanteFiscal).HasName("PK__Comproba__ECDC8002302E6ABA");

            entity.Property(e => e.IdComprobanteFiscal).HasColumnName("idComprobanteFiscal");
            entity.Property(e => e.Itbis18)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("itbis18");
            entity.Property(e => e.Monto)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("monto");
            entity.Property(e => e.Ncf)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("NCF");
            entity.Property(e => e.RncCedula)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("rncCedula");

            entity.HasOne(d => d.RncCedulaNavigation).WithMany(p => p.ComprobantesFiscales)
                .HasForeignKey(d => d.RncCedula)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Comproban__itbis__267ABA7A");
        }
    }
}
