using System;
using System.Linq;

namespace LoveLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            var rand = new Random();
            var intList = Enumerable
                .Range(1, 200)
                .Select(i => rand.Next(1, 11)).ToList();

            var freqDictionary = intList
                .GroupBy(i => i)
                //.OrderBy(i => i.Key)
                .ToDictionary(i => i.Key, i => i.Count());
        }
    }
}
