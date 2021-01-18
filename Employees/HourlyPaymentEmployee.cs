namespace Employees
{
    internal class HourlyPaymentEmployee : Employee
    {
        //private DateTime _Hours;
        public HourlyPaymentEmployee(string Name, string LastName, Positions Position, float Salary) :
            base(Name, LastName, Position, Salary)
        { }

        //public int AddHours
        //{
        //    get => _Hours.Hour;
        //    set => _Hours.AddHours(value);
        //}

        public override double AverageSalary()
        {
            return 20.8 * 8 * _Salary;
        }
    }
}
