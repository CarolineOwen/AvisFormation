using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class MonDbContext : DbContext
    {
        public MonDbContext(DbContextOptions<MonDbContext> options) : base(options) { 
        }

        public DbSet<Formation> Formations { get; set; }
        public DbSet<Avis> Avis { get; set; }
        public DbSet<ContactMessage> ContactMessages { get; set; }

        internal object OrderBy(Func<object, Guid> value)
        {
            throw new NotImplementedException();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Formation>().HasData(
                new
                {
                    Id = 1,
                    Nom = "Langage Java",
                    Description = "Developpeur web Java",
                    NomSeo = "Java"
                },
                new
                {Id=2,
                    Nom = "Langage C++",
                    Description = "Developpeur Informatique appliqué",
                    NomSeo = "C++"
                },
                new
                {
                    Id = 3,
                    Nom = "Langage Python",
                    Description = "Developpeur Intelligence Artificielle",
                    NomSeo = "Python"
                }
                );
        }
    }
}
