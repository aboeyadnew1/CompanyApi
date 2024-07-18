using Company.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
         .HasOne(e => e.Departments)
         .WithMany(d => d.Employees)
         .HasForeignKey(e => e.DepartmentId);
          
            modelBuilder.Entity<Order>()
          .HasOne(o => o.Customer)
          .WithMany(c => c.Orders)
          .HasForeignKey(o => o.CustomerId);

        }
    }
}
