using System;
using System.Collections;
using System.Collections.Generic;

namespace Employees
{
    internal class Staff : IEnumerator, IEnumerable
    {
        private List<Employee> _List = new List<Employee>();

        private int _Position = -1;

        public void AddEmployee(Employee Employee)
        {
            _List.Add(Employee);
        }

        public void Sort()
        {
            _List.Sort();
        }

        public void Print()
        {
            Console.WriteLine($"{_List[_Position].Name} {_List[_Position].LastName} {_List[_Position].Position} = {_List[_Position].AverageSalary()}");
        }

        public object Current
        {
            get
            {
                if (_Position == -1 || _Position >= _List.Count)
                    throw new InvalidOperationException();
                return _List[_Position];
            }
        }

        public bool MoveNext()
        {
            if (_Position < _List.Count - 1)
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
