using System;
using System.Collections.Generic;
using Company;

namespace Exercise1._5x02
{
    class Program
    {
        static void Main(string[] args)
        {
            var emps = new List<Employee>();
            emps.Add(new FullTimeEmployee("Gerard", 15256.56));
            emps.Add(new PartTimeEmployee("Piotr", 150.5, 150));
            emps.Add(new PartTimeEmployee("Hovie", 202, 150));

            var managementAS = new Company.Company();

            emps.ForEach((emp) => managementAS.EmployNewEmployee(emp));

            Console.WriteLine(managementAS.GetMonthlySalaryTotal());
            Console.WriteLine(managementAS.GetMonthlySalaryTotalLinq());
        }
    }
}
