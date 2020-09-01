using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TesoreriaV2.Entidades;

namespace TesoreriaV2.Datos.Mapping
{
    public class CuentaMap : IEntityTypeConfiguration<Cuenta>
    {
        public void Configure(EntityTypeBuilder<Cuenta> builder)
        {
            builder.ToTable("_CUENTAS").HasKey(cta => cta.CUENTA);
        }
    }
}
