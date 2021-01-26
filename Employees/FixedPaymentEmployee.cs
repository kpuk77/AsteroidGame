namespace Employees
{
    internal class FixedPaymentEmployee : Employee
    {
        public FixedPaymentEmployee(string Name, string LastName, Positions Position, float Salary) :
            base(Name, LastName, Position, Salary)
        { }

        public override double AverageSalary()
        {
            return Salary;
        }
    }
}
