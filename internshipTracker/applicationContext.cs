using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace internshipTracker
{
    public class applicationContext : DbContext
    {
        public DbSet<application> applications { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(LocalDB)\MSSQLLocalDB;Database=InternshipTracker;Trusted_Connection=True;MultipleActiveResultSets=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<application>().HasKey(t => t.id); // Explicitly define 'id' as the primary key
            modelBuilder.Entity<application>().HasData(
                new application
                {
                    id = 1,
                    OrganizationName = "test1",
                    Status = "Applied",
                    DateApplied = DateTime.ParseExact("2024-01-15", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    InternshipStartDate = DateTime.ParseExact("2024-05-20", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                },
               new application
               {
                   id = 2,
                   OrganizationName = "test2",
                   Status = "Applied",
                   DateApplied = DateTime.ParseExact("2024-01-15", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                   InternshipStartDate = DateTime.ParseExact("2024-05-20", "yyyy-MM-dd", CultureInfo.InvariantCulture)
               }
            );
        }
    }
}
