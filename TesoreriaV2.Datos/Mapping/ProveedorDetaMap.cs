using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TesoreriaV2.Entidades;

namespace TesoreriaV2.Datos.Mapping
{
    public class ProveedorDetaMap : IEntityTypeConfiguration<ProveedorDeta>
    {
        public void Configure(EntityTypeBuilder<ProveedorDeta> builder)
        {
            builder.ToTable("ProveedoresDeta").HasKey(pd => pd.ID);
        }
    }
}
