using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TesoreriaV2.Datos.Mapping;
using TesoreriaV2.Entidades;

namespace TesoreriaV2.Datos
{
    public class DbContextContabilidad : DbContext
    {
        public DbSet<Cuenta> cuentas { get; set; }

        public DbContextContabilidad(DbContextOptions<DbContextContabilidad> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CuentaMap());

        }


    }
}
