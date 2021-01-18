using System;
using System.Collections;
using System.Collections.Generic;

namespace Employees
{
    internal class Staff : IEnumerator, IEnumerable
    {
        private List<Employee> __List = new List<Employee>();

        private int _Position = -1;

        public void AddEmployee(Employee Employee)
        {
            __List.Add(Employee);
        }

        public void Sort()
        {
            __List.Sort();
        }

        public void Print()
        {
            Console.WriteLine($"{__List[_Position]._Name} {__List[_Position]._LastName} {__List[_Position]._Position} = {__List[_Position].AverageSalary()}");
        }

        public object Current
        {
            get
            {
                if (_Position == -1 || _Position >= __List.Count)
                    throw new InvalidOperationException();
                return __List[_Position];
            }
        }

        public bool MoveNext()
        {
            if (_Position < __List.Count - 1)
            {
                _Position++;
                return true;
            }
            else
                return false;
        }

        public void Reset()
        {
            _Position = -1;
        }

        public IEnumerator GetEnumerator()
        {
            return this;
        }
    }
}
