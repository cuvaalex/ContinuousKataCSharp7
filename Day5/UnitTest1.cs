using System;
using System.Linq;
using Xunit;

namespace Day5
{
    public class UnitTest1
    {
        public void printTableMultiplication(int number)
        {
            foreach (var i in Enumerable.Range(1, 10))
            {
                Console.WriteLine($"{number} x {i} = {number*i}");
            }
        }
    }
}