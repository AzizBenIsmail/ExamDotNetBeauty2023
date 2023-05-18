using AM.Core.Domain;
using AM.Data.Configurations;
using ExamDotNetAzizBenIsmail;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace AM.Data
{
    public class AMContext : DbContext
    {
        //public DbSet<Flight> Flights { get; set; } // pour tous les classes

        public DbSet<Client> Clients { get; set; } // pour tous les classes

        public DbSet<Prestataire> Prestataires { get; set; } // pour tous les classes
        public DbSet<Prestation> Prestations { get; set; } // pour tous les classes
        public DbSet<RDV> RDVs { get; set; } // pour tous les classes

        //parametrer l'acces a la bd
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb; 
                    Initial Catalog = BeautyAzizBenIsmail;  
                    Integrated Security = true");
            //LazyLoading
            optionsBuilder.UseLazyLoadingProxies();

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new FlightConfig());
            modelBuilder.ApplyConfiguration(new RDVConfig());

        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<String>()
                .HaveMaxLength(150);
        }
    }
}