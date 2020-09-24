using System.Collections.Generic;
using System.Linq;

namespace Company2
{
    class Company
    {
        public List<Employee> Employees { get; } = new List<Employee>();
        public double GetMonthlySalaryTotal()
        {
            double sum = 0;
            foreach (Employee emp in Employees)
            {
                sum += emp.GetMonthlySalary();
            }
            return sum;
        }

        public double GetMonthlySalaryTotalLinq() =>
            Employees.Sum((emp) => emp.GetMonthlySalary());
        public void EmployNewEmployee(Employee emp) => Employees.Add(emp); 
    }
}
