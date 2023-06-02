using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    //cortex : db tabloları ile proje classlarını bağlama
    public class NorthwindContex:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=NORTHWND;User Id=sa;Password=1;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=True");
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Personel> Personels { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Personel>().ToTable("Employees");
            modelBuilder.Entity<Personel>().Property(p=>p.Id).HasColumnName("EmployeeID");
            modelBuilder.Entity<Personel>().Property(p=>p.Name).HasColumnName("FirstName");
            modelBuilder.Entity<Personel>().Property(p => p.Surname).HasColumnName("LastName");

        }
    }
}
