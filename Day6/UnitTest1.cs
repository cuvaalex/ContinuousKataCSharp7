using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic;
using Xbehave;
using Xunit;

namespace Day6
{
    
    public class UnitTest1
    {
        [Scenario]
        [Example(1, new string[] {"Haker"}, "Hkr ae")]
        [Example(2, new string[] {"Haker", "Rank"}, "Hkr ae\nRn ak")]
        public void ShouldPrintNLineOfResult(int nb, string[] texts, String expected, String result)
        {
            $"Given the number {nb}"
                .x(() => { });
            $"And texts {texts}"
                .x(() => {});
            $"When I ask resolve solution"
                .x(() => result = PrintResults(nb, texts));
            $"Then I expect {expected}"
                .x(body: () => Assert.Equal(expected, result));
        }

        [Fact]
        public void ShouldReturnTwoStringOfOddAndEvenLetters()
        {
            var text = "HakerRank";
            var expected = new List<String>() {"Hkrak", "aeRn"};

            List<String> actual = ExtractEvenOdd(text);
            
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldReturnTwoListOfOddEvenWhenTwoText()
        {
            var texts = new List<String>() {"Haker", "Rank"};
            var expected = new List<List<String>>() {new List<string>(){"Hkr", "ae"}, new List<string>(){"Rn", "ak"}};

            var actual = ExtractEvenOdds(texts);
        }
        

        public string PrintResults(int nb, string[] texts)
        {
            var results = ExtractEvenOdds(texts.ToList());
            var printOut = "";
            for (int i = 0; i < nb; i++)
            {
                if (i > 0) printOut += "\n";
                printOut += results[i][0] + " " + results[i][1];
            }

            return printOut;
        }

        private List<List<String>> ExtractEvenOdds(List<string> texts)
        {
            var results = new List<List<String>>();
            foreach (string text in texts)
            {
                results.Add(ExtractEvenOdd(text));
            }

            return results;
        }

        private List<string> ExtractEvenOdd(String text)
        {
            var textSize = text.Length;
            var oddText = "";
            var evenText = "";
            for (int i = 0; i < textSize; i++)
            {
                if (i % 2 == 0)
                {
                    oddText += text[i];
                }
                else
                {
                    evenText += text[i];
                }
            }
            return new List<string>() {oddText, evenText};
        }
    }
}