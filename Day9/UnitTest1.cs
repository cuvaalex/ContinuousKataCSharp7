using System;
using System.ComponentModel.Design;
using NFluent;
using Xbehave;
using Xunit;

namespace Day9
{
    public class UnitTest1
    {
        static int factorial(int n)
        {
            if (n > 1)
            {
                return n * factorial(n-1);
            }
            else if(n == 1)
            {
                return 1;
            }
            return 0;
        }
        
        [Scenario]
        [Example(0,0)]
        [Example(1,1)]
        [Example(2,2)]
        [Example(3,6)]
        public void ShouldReturnFact(int n, double expected, double actual)
        {
            $"Given {n}"
                .x(() => { });
            $"When compute Factoriel"
                .x(() => actual = factorial(n));
            $"Then result {actual} should be same than {expected}"
                .x(() => Check.That(actual).Equals(expected));
        }
    }
}