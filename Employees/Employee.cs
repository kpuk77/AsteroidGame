using System;

namespace Employees
{
    internal abstract class Employee : IComparable
    {
        public Employee(string Name, string LastName, Positions Position, float Salary)
        {
            this.Name = Name;
            this.LastName = LastName;
            this.Position = Position;
            this.Salary = Salary;
        }

        public string Name { get; set; }
        public string LastName { get; set; }
        public Positions Position { get; set; }
        protected float Salary { get; set; }

        public abstract double AverageSalary();

        public int CompareTo(object obj)
        {
            if (obj == null)
                throw new ArgumentNullException();

            var comp = obj as Employee;
            if (Name[0] > comp.Name[0])
                return 1;
            if (Name[0] < comp.Name[0])
                return -1;
            return 0;
        }

        public override string ToString()
        {
            return $"{Name} {LastName} {Position} = {AverageSalary()}";
        }

        //public int CompareTo([AllowNull] string other)
        //{
        //    if (other)
        //}
    }
}
