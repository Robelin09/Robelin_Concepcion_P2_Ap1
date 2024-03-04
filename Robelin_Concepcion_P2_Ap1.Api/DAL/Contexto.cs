using Microsoft.EntityFrameworkCore;
using Library.Models;

namespace Robelin_Concepcion_P2_Ap1.Api.DAL
{
    public class Contexto : DbContext
    {

        public DbSet<Vehiculos> Vehiculos { get; set; }
        public DbSet<Accesorios> Accesorios { get; set; }
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Accesorios>().HasData(new List<Accesorios>()
    {
            new Accesorios() { AccesorioId = 1, Descripción = "Camara Trasera"},
            new Accesorios() { AccesorioId = 2, Descripción = "Pantalla Interior"},
            new Accesorios() { AccesorioId = 3, Descripción = "Interior en Piel" },
            new Accesorios() { AccesorioId = 4, Descripción = "Sun Roof" },
            new Accesorios() { AccesorioId = 5, Descripción = "Aros de Lujo"},
    });
        }
    }
}
