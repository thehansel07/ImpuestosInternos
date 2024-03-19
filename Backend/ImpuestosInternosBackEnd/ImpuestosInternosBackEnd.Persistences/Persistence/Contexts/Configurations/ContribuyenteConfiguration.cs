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
    public class ContribuyenteConfiguration : IEntityTypeConfiguration<Contribuyente>
    {
        public void Configure(EntityTypeBuilder<Contribuyente> entity)
        {
            entity.HasKey(e => e.RncCedula).HasName("PK__Contribu__38AA49B3D8137A32");

            entity.ToTable("Contribuyente");

            entity.Property(e => e.RncCedula)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("rncCedula");

            entity.Property(e => e.Estatus).HasColumnName("estatus");

            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("nombre");

            entity.Property(e => e.Tipo)
                .HasMaxLength(30)
                .HasColumnName("tipo");
        }
    }
}
