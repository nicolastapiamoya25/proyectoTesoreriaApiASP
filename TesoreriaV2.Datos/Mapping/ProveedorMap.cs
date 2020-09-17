using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TesoreriaV2.Entidades;

namespace TesoreriaV2.Datos.Mapping
{
    public class ProveedorMap : IEntityTypeConfiguration<Proveedores>
    {
        public void Configure(EntityTypeBuilder<Proveedores> builder)
        {
            builder.ToTable("_TESORERIA_PROVEEDORES").HasKey(p => p.rut);  
        }
    }
}
