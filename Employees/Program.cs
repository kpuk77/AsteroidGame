using System;

//  1.Построить три класса(базовый и 2 потомка), описывающих некоторых работников с почасовой оплатой (один из потомков) и фиксированной оплатой (второй потомок).
//  а) Описать в базовом классе абстрактный метод для расчёта среднемесячной заработной платы. Для «повременщиков» формула для расчета такова: «среднемесячная заработная плата = 20.8 * 8 * почасовая ставка», для работников с фиксированной оплатой «среднемесячная заработная плата = фиксированная месячная оплата».
//  б) Создать на базе абстрактного класса массив сотрудников и заполнить его.
//  в) *Реализовать интерфейсы для возможности сортировки массива, используя Array.Sort().
//  г) *Создать класс, содержащий массив сотрудников, и реализовать возможность вывода данных с использованием foreach.

namespace Employees
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Log's:");
            Console.ReadLine();

            #region Bardak

            //Staff microsoftCompany = new Staff();

            //microsoftCompany.AddEmployee(new HourlyPaymentEmployee("Ivan", "Ivanov", Positions.Freelancer, 13));
            //microsoftCompany.AddEmployee(new FixedPaymentEmployee("Vladimir", "Putin", Positions.HiredWorker, 500));
            //microsoftCompany.AddEmployee(new FixedPaymentEmployee("Dmitry", "Medvedev", Positions.HiredWorker, 300));
            //microsoftCompany.AddEmployee(new FixedPaymentEmployee("Angela", "Merkel", Positions.HiredWorker, 900));
            //microsoftCompany.AddEmployee(new HourlyPaymentEmployee("Donald", "Trump", Positions.Freelancer, 10));
            //microsoftCompany.AddEmployee(new HourlyPaymentEmployee("C#", "Programmer", Positions.Freelancer, 1000));

            //microsoftCompany.Sort();

            //foreach (var item in microsoftCompany)
            //{
            //    Console.WriteLine(item);
            //}

            #endregion
        }
    }
}
