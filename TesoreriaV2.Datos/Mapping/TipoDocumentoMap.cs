using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TesoreriaV2.Entidades;

namespace TesoreriaV2.Datos.Mapping
{
    public class TipoDocumentoMap : IEntityTypeConfiguration<TipoDocumento>
    {
        public void Configure(EntityTypeBuilder<TipoDocumento> builder)
        {
            builder.ToTable("_TESORERIA_TIPO_DOCUMENTOS").HasKey(td => td.CODIGO);
        }
    }
}
