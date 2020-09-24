using System;
using System.Collections.Generic;
using System.Text;

namespace Company2
{
    class PartTimeStudent : PartTimeEmployee, IStudent
    {
        public int StartOfEducation { get; set; }
        public PartTimeStudent(string name, double hourlyWage, int hoursPerMonth) : base(name, hourlyWage, hoursPerMonth)
        {

        }
        public void Register(int year)
        {
            StartOfEducation = year;
        }

        public override double GetMonthlySalary()
        {
            return base.GetMonthlySalary();
        }

    }
}
