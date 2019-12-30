using System;
using System.Collections.Generic;
using System.Linq;
using Day8;

namespace Day8Console
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
            var nbPhone = Convert.ToInt32(Console.ReadLine());
            var listOfLines = new List<string>();
            for(var x = 0; x < nbPhone*2; x++){
                listOfLines.Add(Console.ReadLine());        
            }
            var book = new PhoneBook();
            book.ExtractSimilar(nbPhone, listOfLines).ToList().ForEach(Console.WriteLine);

        }
    }
}