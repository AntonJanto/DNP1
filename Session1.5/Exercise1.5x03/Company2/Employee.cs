﻿namespace Company2
{
    abstract class Employee
    {
        public string Name { get; }

        public Employee(string name)
        {
            Name = name;
        }

        public abstract double GetMonthlySalary();
    }
}
