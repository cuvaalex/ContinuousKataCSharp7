using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CompareTheTriplet
{
    public class UnitTest1
    {
        
        static List<int> compareTriplets(List<int> a, List<int> b)
        {
            var alice = a.Select((x, i) => x > b[i]).Count(v => v == true);
            var bob = b.Select((x, i) => x > a[i]).Count(v => v == true);;
            
            return new List<int>() {alice, bob};
        }
        
        [Fact]
        public void ShouldAliceReceive1PointIfAliceTripletIsBigger()
        {
            var expectedScore = new List<int>() {1,0};
            var alicetriplet = new List<int>() {36};
            var bobtriplet = new List<int>() {26};

            var actualScore = compareTriplets(alicetriplet, bobtriplet);
            
            Assert.Equal(expectedScore, actualScore);
        }
        
        [Fact]
        public void ShouldAliceReceive2PointIfAliceTripletsIsBigger()
        {
            var expectedScore = new List<int>() {2,0};
            var alicetriplet = new List<int>() {36, 78, 0};
            var bobtriplet = new List<int>() {26,52, 0};

            var actualScore = compareTriplets(alicetriplet, bobtriplet);
            
            Assert.Equal(expectedScore, actualScore);
        }

        [Fact]
        public void ShouldBobReceive2PointIfAliceTripletsIsBigger()
        {
            var expectedScore = new List<int>() {0,2};
            var bobtriplet = new List<int>() {36, 78, 0};
            var alicetriplet = new List<int>() {26,52, 0};

            var actualScore = compareTriplets(alicetriplet, bobtriplet);
            
            Assert.Equal(expectedScore, actualScore);
        }

    }
}