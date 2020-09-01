using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TesoreriaV2.Entidades;

namespace TesoreriaV2.Datos.Mapping
{
    public class DetaProveedoresMap : IEntityTypeConfiguration<DetaProveedores>
    {
        public void Configure(EntityTypeBuilder<DetaProveedores> builder)
        {
            builder.ToTable("_TESORERIA_DETA_PROVEEDORES").HasKey(dp => dp.ID);
        }
    }
}
