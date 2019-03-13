using Microsoft.EntityFrameworkCore;
using rowa.repository.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rowa.repository
{
    public class DatabaseContext : DbContext
    {
        public DbSet<PageVisit> PageVisit { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=SERVER;Port=PORT;database=DATABASE;user=USERNAME;password=PASSWORD");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PageVisit>(en =>
            {
                en.HasKey(e => e.Id);
            });
        }
    }
}
