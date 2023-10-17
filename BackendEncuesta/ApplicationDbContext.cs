using BackendEncuesta.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace BackendEncuesta
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
                         
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Encuesta> Encuestas { get; set; }

        public DbSet<ComunaResidencia> ComunasResidencia { get; set; }

        public DbSet<ComunaTrabajo> ComunasTrabajo { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<ModalidadTrabajo> ModalidadTrabajos { get; set; }
        public DbSet<TipoTransporte> TipoTransportes { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        
    }
}
