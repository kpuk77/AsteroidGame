using System;

namespace Employees
{
    internal abstract class Employee : IComparable
    {
        public Employee(string Name, string LastName, Positions Position, float Salary)
        {
            _Name = Name;
            _LastName = LastName;
            _Position = Position;
            _Salary = Salary;
        }

        public string _Name { get; set; }
        public string _LastName { get; set; }
        public Positions _Position { get; set; }
        protected float _Salary { get; set; }

        public abstract double AverageSalary();

        public int CompareTo(object obj)
        {
            if (obj == null)
                throw new ArgumentNullException();

            var comp = obj as Employee;
            if (_Name[0] > comp._Name[0])
                return 1;
            if (_Name[0] < comp._Name[0])
                return -1;
            return 0;
        }

        public override string ToString()
        {
            return $"{_Name} {_LastName} {_Position} = {AverageSalary()}";
        }

        //public int CompareTo([AllowNull] string other)
        //{
        //    if (other)
        //}
    }
}
