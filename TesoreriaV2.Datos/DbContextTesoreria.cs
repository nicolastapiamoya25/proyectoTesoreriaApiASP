using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TesoreriaV2.Datos.Mapping;
using TesoreriaV2.Entidades;

namespace TesoreriaV2.Datos
{
    public class DbContextTesoreria : DbContext
    {
        public DbSet<Proveedores> proveedores { get; set; }
        public DbSet<Perfil> perfiles { get; set; }
        public DbSet<Personas> personas { get; set; }
        public DbSet<TipoDocumento> tipodocumentos { get; set; }

        public DbSet<ProveedorEnca> proveedoresencas { get; set; }
        public DbSet<ProveedorDeta> proveedoresdetas { get; set; }

        public DbSet<CentroCosto> centrocostos { get; set; }



        public DbContextTesoreria(DbContextOptions<DbContextTesoreria> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ProveedorMap());
            modelBuilder.ApplyConfiguration(new PerfilMap());
            modelBuilder.ApplyConfiguration(new PersonasMap());
            modelBuilder.ApplyConfiguration(new TipoDocumentoMap());
            modelBuilder.ApplyConfiguration(new ProveedorEncaMap());
            modelBuilder.ApplyConfiguration(new ProveedorDetaMap());
            modelBuilder.ApplyConfiguration(new CentroCostoMap());

        }
    }
}
