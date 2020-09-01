using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TesoreriaV2.Entidades;

namespace TesoreriaV2.Datos.Mapping
{
    public class ProveedorEncaMap : IEntityTypeConfiguration<ProveedorEnca>
    {
        public void Configure(EntityTypeBuilder<ProveedorEnca> builder)
        {
            builder.ToTable("ProveedoresEnca").HasKey(pe => pe.CORRELATIVO);
        }
    }
}
