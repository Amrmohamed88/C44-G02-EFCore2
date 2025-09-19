using Demo.modelConfigyrationEmployee;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DbContextDatabase
{
    public class CompanyDbContext : DbContext 
    {
        public CompanyDbContext():base()
        {
             
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=Companytest;Trusted_Connection=True;TrustServerCertificate=True");
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Employee Entity
            modelBuilder.Entity<Employee>().ToTable("EmployessTable");
            modelBuilder.Entity<Employee>().HasKey(E => E.EmpId);
            modelBuilder.Entity<Employee>().Property(E => E.EmpId).UseIdentityColumn(10, 10);
            modelBuilder.Entity<Employee>().Property(E => E.EmpName).HasColumnName("EmployeeName").HasColumnType("varchar");
            modelBuilder.Entity<Employee>().Property(E => E.Salary).HasPrecision(10, 2);
            modelBuilder.Entity<Employee>().ToTable(E => E.HasCheckConstraint("check emp age range ", "[Age] Between 22 and 40"));
            modelBuilder.Entity<Employee>().Property(E => E.Email).IsRequired();
            modelBuilder.Entity<Employee>().Ignore(E => E.UserName);
            #endregion
            modelBuilder.Entity<Department>().HasKey(D => D.DeptID);
            modelBuilder.Entity<Department>( D=>
                {
                    D.ToTable("DepartmentId");
                    D.HasKey(D => D.DeptID);
                    D.Property(D=> D.DeptID).UseIdentityColumn(10, 10);
                    D.Property(D => D.DeotName).HasColumnName("Departmentname").HasColumnType("varchar").HasMaxLength(50)
                    .IsRequired(false);
                    D.Property(D => D.Dateifceation).IsRequired(false).HasDefaultValueSql("GETDATE()");
                    D.Ignore(D => D.Serial);


                });
            

            modelBuilder.ApplyConfiguration<Employee>(new EmployeeConfiguration());
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            
        }

        DbSet<Employee> employees { get; set; }


    }
}
