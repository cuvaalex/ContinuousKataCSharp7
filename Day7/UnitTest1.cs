using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xbehave;

namespace Day7
{
    public class UnitTest1
    {
        [Scenario]
        [Example(4, new []{1, 2, 3, 4}, "4 3 2 1")]
        public void ShouldReverse(int nb, int[] numbers, String expected, String actual)
        {
            $"Given a text {numbers}"
                .x(() => { });
            $"When call reverse"
                .x(() => actual = ReverseChar(numbers));
            $"Then we expect {expected}"
                .x(() => Assert.Equal(expected, actual));
        }

        [Fact]
        public void ShouldReturnArray4321When1234()
        {
            var expected = new string[] {"4", "3", "2", "1"};
            var arrayOfChar = new string[]{"1", "2", "3", "4"};

            var actual = ReverseArray(arrayOfChar);
            
            Assert.Equal(expected, actual);
        }

        private string[] ReverseArray(string[] arrayOfChar)
        {
            return arrayOfChar.Reverse().ToArray();
        }


        private string ReverseChar(int[] numbers)
        {
            var reverseOrder = numbers.Reverse();
            var printOut = "";
            var count = 0;
            foreach (var number in reverseOrder)
            {
                if (count > 0) printOut += " ";
                printOut += number;
                count++;
            }

            return printOut;
        }
    }
}