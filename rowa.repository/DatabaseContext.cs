using Microsoft.EntityFrameworkCore;
using rowa.repository.Entities;
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
        public DbSet<ErrorLog> ErrorLog { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<PerformanceLog> PerformanceLog { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;Port=3306;database=rowa;user=sa;password=t&nmeAqL@?mDB8j5");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PageVisit>(en =>
            {
                en.HasKey(e => e.Id);
            });

            modelBuilder.Entity<ErrorLog>(en =>
            {
                en.HasKey(e => e.Id);
            });

            modelBuilder.Entity<PerformanceLog>(en =>
            {
                en.HasKey(e => e.Id);
            });

            modelBuilder.Entity<User>(en =>
            {
                en.HasKey(e => e.Id);
            });

            modelBuilder.Entity<UserRole>(en =>
            {
                en.HasKey(e => e.Id);
            });
        }
    }
}
