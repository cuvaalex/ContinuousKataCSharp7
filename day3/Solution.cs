using System;
using Xunit;

class Solution {
    // public static void Main(string[] args) {
    //     int N = Convert.ToInt32(Console.ReadLine());
    //     
    // }

    public static String IdentifyMessage(int N)
    {
        if (!isEven(N)) return "Weird";
        if ((N>=2 && N <=5) || N > 20)
        {
            return "Not Weird";    
        }
        return "Weird";
    }

    private static bool isEven(int N)
    {
        return N % 2 == 0;
    }
}

public class SolutionTest
{
    [Theory]
    [InlineData(3)]
    [InlineData(5)]
    [InlineData(7)]
    [InlineData(11)]
    [InlineData(13)]
    [InlineData(15)]
    [InlineData(17)]
    [InlineData(19)]
    [InlineData(21)]
    [InlineData(99)]
    public void Should_Return_Weird_if_number_is_odd(int N)
    {
        String expected = "Weird";
        var result = Solution.IdentifyMessage(N);
        
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(2)]
    [InlineData(4)]
    public void Should_Return_Not_Weird_if_number_is_even_AND_between_2_5(int N)
    {
        String expected = "Not Weird";
        var actual = Solution.IdentifyMessage(N);
        
        Assert.Equal(expected, actual);
    }
    
    [Theory]
    [InlineData(6)]
    [InlineData(8)]
    [InlineData(10)]
    [InlineData(12)]
    [InlineData(14)]
    [InlineData(16)]
    [InlineData(18)]
    [InlineData(20)]
    public void Should_Return_Weird_if_number_is_even_AND_between_6_20(int N)
    {
        String expected = "Weird";
        var actual = Solution.IdentifyMessage(N);
        
        Assert.Equal(expected, actual);
    }
    
    [Theory]
    [InlineData(22)]
    [InlineData(30)]
    public void Should_Return_Weird_if_number_is_even_AND_greater_20(int N)
    {
        String expected = "Not Weird";
        var actual = Solution.IdentifyMessage(N);
        
        Assert.Equal(expected, actual);
    }

}