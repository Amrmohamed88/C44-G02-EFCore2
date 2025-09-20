using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    internal class Employee
    {
        
        public int EmpId { get; set; }

        //[Column(name: "EmployeeName", TypeName = "varchar")]
        //[MaxLength(50, ErrorMessage = "Name cannot more than 50 char ")] // message appliction validation 
        //[MinLength(50, ErrorMessage = "Name cannot less than 3 char ")] // appliction validation
        public string? EmpName { get; set; }

        //[Column(TypeName = "decimal (10,2)")]
        public decimal Salary { get; set; }
        //[Precision (10,2)]
        //[Range(22, 40)] // appliction validation
                        // [AllowedValues(22,24,26)]
        public int Age { get; set; }
        //[Required]
        //[DataType(DataType.EmailAddress)] // UI Hint [frontEnd]
        public string? Email { get; set; }
        //[DataType(DataType.Password)]
        public string? Password { get; set; }

        //[Required]
        //[Phone]  // appliction validation
        //[DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; set; }

        //[NotMapped]
        public string UserName => Email.Split('@')[0];
    }
}
