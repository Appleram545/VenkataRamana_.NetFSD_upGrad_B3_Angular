using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EmployeeManagement.Models;

namespace EmployeeManagement.Models
{
    public class ApplicationDbContext : DbContext
    {


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {

         }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Dept> Depts{get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                        .HasOne(e => e.Dept)
                        .WithMany(d => d.Employees)
                        .HasForeignKey(e => e.DeptId);
        }

    }
}

