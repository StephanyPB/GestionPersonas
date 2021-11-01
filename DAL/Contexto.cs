using GestionPersonas.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPersonas.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Personas> Personas { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Grupos> Grupos { get; set; }
         public DbSet<Aportes> Aportes { get; set; }
        public DbSet<TipoAportes> tipoAportes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = DATA\PeopleGestor.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TipoAportes>().HasData(
                new TipoAportes { TipoAporteId = 1, Descripcion = "Asilo De Ancianos", MontoDeseado = 3000000000},
                  new TipoAportes { TipoAporteId = 2, Descripcion = "Fundacion de Cancer ", MontoDeseado = 5000000000 },
                   new TipoAportes { TipoAporteId = 3, Descripcion = "Orfanato ", MontoDeseado = 3000000000 },
                    new TipoAportes { TipoAporteId = 4, Descripcion = "Ciencia ", MontoDeseado = 2000000000 },
                     new TipoAportes { TipoAporteId = 5, Descripcion = "Educacion ", MontoDeseado = 1000000000},
                      new TipoAportes { TipoAporteId = 6, Descripcion = "Cementerio ", MontoDeseado = 1000000000 },
                      new TipoAportes { TipoAporteId = 7, Descripcion = "Zoologico", MontoDeseado = 1000000000 }
                );
        }
    }
}
