using System;
using System.Collections.Generic;
using System.Linq;
using NFluent;
using Xbehave;
using Xunit;
using static Xunit.Assert;

namespace Day8
{

    public class PhoneBook {
        public IEnumerable<string> ExtractSimilar(int nb, IReadOnlyCollection<string> lines)
        {
            var filteredPhoneBooks = FilterPhoneBook(nb, lines);
            var printNice = filteredPhoneBooks;
            return printNice.ToList();
        }

        private static IEnumerable<string> ExtractPhoneBook(int nb, IEnumerable<string> textReceived)
        {
                var phoneBook = textReceived
                    .Where((x, idx) => idx < nb)
                    .Select<string, string>((x, idx) =>
                    {
                        var pair = x.Split(' ');
                        return $"{pair[0]}={pair[1]}";
                    });
                return phoneBook;
        }

        private IEnumerable<string> ExtractListOfNames(int nb, IEnumerable<string> lines)
        {
            var listOfNames = lines.Where((line, idx) => idx >= nb);
            return listOfNames;
        }
        
        private IEnumerable<string> FilterPhoneBook(int nb, IReadOnlyCollection<string> lines)
        {
            var filter = ExtractListOfNames(nb, lines);
            var phoneBooks = ExtractPhoneBook(nb, lines);
            var filteredPhoneBook = filter.Select<string, string>(name =>
            {
                try
                {
                    var phoneBook = phoneBooks.Single(phone => phone.Contains(name));
                    return phoneBook;
                }
                catch (Exception e)
                {
                    return $"{name}=Not Found";
                }
            });
            return filteredPhoneBook;
        }

        #region XUnit

        [Scenario]
        [Example(3
            ,new[] {"sam 99912222", "tom 11122222", "harry 12299933", "sam", "edward", "harry"}
            ,new[] {"sam=99912222", "edward=Not found","harry=12299933"})]
        public void ShouldReturnTheTupleFound(int nb, string[] textReceived, string[] expected, IEnumerable<string> actual)
        {
            $"Given the following text {textReceived}"
                .x(() => {});
            $"When I extract the similar {nb} phonebook"
                .x(() => actual = ExtractSimilar(nb, textReceived));
            $"Then I expect {actual} be same than {expected}"
                .x(() => Equal(expected, actual));
        
        }

        [Fact]
        public void ShouldExtractPhoneBook()
        {
            var expected = new List<string>()
            {
                "sam=99912222"
                ,"tom=11122222"
                ,"harry=12299933"
            };
            var lines = new List<string>() {"sam 99912222", "tom 11122222", "harry 12299933", "same", "henry", "harry"};
            
            var actual = ExtractPhoneBook(3, lines );
            
            Equal(expected, actual);
        }

        [Fact]
        public void ShouldExtractListOfName()
        {
            var expected = new string[] {"same", "henry", "harry"};

            var actual = ExtractListOfNames(3, new[] {"sam 99912222", "tom 11122222", "harry 12299933", "same", "henry", "harry"});
            
            Equal(expected, actual);
        }
        
        [Fact]
        public void ShouldExtractThe2PhoneBook()
        {
            var expected = new Dictionary<String, String>()
            {
                {"sam", "99912222"},
                {"henry", "Not found"},
                {"tom", "11122222"},
            };
            var lines = new string[] {"sam 99912222", "tom 11122222", "harry 12299933", "sam", "henry", "tom"};

            var actual = FilterPhoneBook(3, lines.ToList());

            Check.That(actual).HasSize(3);
            Check.That(actual).ContainsExactly(expected);
        }

        [Fact]
        public void ShouldNicePrintTheResult()
        {
            var expected = new string[]
            {"sam=99912222"
            ,"henry=Not found"
            , "tom=11122222"
            }.ToList();
            var lines = new string[] {"sam 99912222", "tom 11122222", "harry 12299933", "sam", "henry", "tom"};
            
            var printResult = ExtractSimilar(3, lines.ToList());

            Check.That(printResult).CountIs(3);
            Check.That(printResult).ContainsExactly(expected);

        } 

        #endregion
    }
}