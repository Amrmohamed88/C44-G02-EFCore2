using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Demo.modelConfigyrationEmployee
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        void IEntityTypeConfiguration<Employee>.Configure(EntityTypeBuilder<Employee> builder)
        {          
            builder.Property(E => E.EmpName).
           HasColumnName("EmployeeName").HasColumnType("varchar").HasMaxLength(50);
            builder.Property(E => E.Salary).HasPrecision(10, 2);
            builder.ToTable(T => T.HasCheckConstraint("check_Employee_Age", "[Age] Between 22 and 40"));
        }
    }
}
