using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MissingNumber
{
    public class UnitTest1
    {
        static int[] MissingNumbers(int[] arr, int[] brr)
        {
            var frequencyArr = arr.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
            var frequencyBrr = brr.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());

            return frequencyBrr
                .Keys
                .Where(keyBrr => !frequencyArr.ContainsKey(keyBrr) 
                                 || (frequencyBrr[keyBrr] > frequencyArr[keyBrr]))
                .OrderBy(i => i)
                .ToArray();
        }
        
        
        [Fact]
        public void Should_Return_Missing_number_204()
        {
            int[] arr = {203, 203, 204, 205};
            int[] brr = {203, 203, 204, 204, 205};

            var expected = new[] {204};
            var actual = MissingNumbers(arr, brr);
            
            Assert.True(expected.All(shouldItem => actual.Any(isItem => isItem == shouldItem)));
        }
        
        [Fact]
        public void Should_Return_Missing_number_3_7_8_10_12()
        {
            var arr = Array.ConvertAll("11 4 11 7 13 4 12 11 10 14".Split(' '), Convert.ToInt32);
            var brr = Array.ConvertAll("11 4 11 7 3 7 10 13 4 8 12 11 10 14 12".Split(' '), Convert.ToInt32);

            var expected = Array.ConvertAll("3 7 8 10 12".Split(' '), Convert.ToInt32);
            var actual = MissingNumbers(arr, brr);
            
            Assert.True(expected.All(shouldItem => actual.Any(isItem => isItem == shouldItem)));
        }

    }
}