using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TesoreriaV2.Entidades;

namespace TesoreriaV2.Datos.Mapping
{
    public class EncaProveedoresMap : IEntityTypeConfiguration<EncaProveedores>
    {
        public void Configure(EntityTypeBuilder<EncaProveedores> builder)
        {
            builder.ToTable("_TESORERIA_ENCA_PROVEEDORES").HasKey(ec => ec.CORRELATIVO);
        }
    }
}
