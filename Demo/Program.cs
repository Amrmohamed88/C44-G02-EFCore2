using Demo.DbContextDatabase;
using Microsoft.EntityFrameworkCore;

namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using CompanyDbContext company = new CompanyDbContext();
            Employee employee = new Employee()
            {
             EmpName = "amr",
             Age = 30 ,
             Email = "amr@gamil.com",
             Password = "P@sswrd",
             PhoneNumber = "01123293801",
             Salary = 100000
            };

            //var Employeestate = company.Entry<Employee>(employee).State;
            //Console.WriteLine(Employeestate); //Detached

            //Console.WriteLine("=====================");

            //company.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            //Employeestate = company.Entry<Employee>(employee).State;
            //Console.WriteLine(Employeestate); //Detached

            #region Add new Row in table employees in Database

            //company.Set<Employee>().Add(employee);
            //company.Add(employee);
            //Console.WriteLine("After Adding");

            //Console.WriteLine(company.Entry(employee).State);
            //Console.WriteLine($"Emp = {employee.EmpId}");

            //company.SaveChanges();
            //Console.WriteLine("after savechange");

            //Console.WriteLine(company.Entry(employee).State);
            //Console.WriteLine($"Emp = {employee.EmpId}");

            #endregion
            
            company.Set<Employee>().Remove(employee);
            Console.WriteLine("after delete");

            Console.WriteLine($"{employee.EmpName} _ {employee.Salary}");


            #region IEnumerable
            //List<int> num = new List<int> { 1, 2, 3, 4, 5 };
            //IEnumerable<int> result = num.Where(n => n > 2);
            //foreach (var n in result)
            //    Console.WriteLine(n);
            #endregion


        }
    }
}
