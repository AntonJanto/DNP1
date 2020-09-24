namespace Company2
{
    class PartTimeEmployee : Employee
    {
        public double HourlyWage { get; }
        public int HoursPerMonth { get; set; }
        public PartTimeEmployee(string name, double hourlyWage, int hoursPerMonth) : base(name)
        {
            HourlyWage = hourlyWage;
            HoursPerMonth = hoursPerMonth;
        }
        public override double GetMonthlySalary() => HourlyWage * HoursPerMonth;
    }
}
