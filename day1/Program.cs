using System;
using System.Collections.Generic;
using System.IO;

class Solution
{
    static void Main(String[] args)
    {
        int i = 4;
        double d = 4.0;
        string s = "HackerRank ";

        // Declare second integer, double, and String variables.
        int anInt;
        Double aDouble;
        String aString;

        // Read and save an integer, double, and String to your variables.
        anInt = Int32.Parse(Console.ReadLine());
        aDouble = Double.Parse(Console.ReadLine());
        aString = Console.ReadLine();

        // Print the sum of both integer variables on a new line.
        Console.WriteLine($"{(i+anInt):G}");
        // Print the sum of the double variables on a new line.
        Console.WriteLine($@"{(d + aDouble):N1}");
        // Concatenate and print the String variables on a new line
        // The 's' variable above should be printed first.
        Console.WriteLine($"{s} {aString}");
    }
}
