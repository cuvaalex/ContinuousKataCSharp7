using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using NFluent;
using Xbehave;
using Xunit;
using static Xunit.Assert;

namespace Day8
{

    public class PhoneBook {

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
        
        public IEnumerable<string> FilterPhoneBook(int nb, IReadOnlyCollection<string> lines)
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
                    return "Not found";
                }
            });
            return filteredPhoneBook;
        }

        #region XUnit

        [Scenario]
        [Example(3
            ,new[] {"sam 99912222", "tom 11122222", "harry 12299933", "sam", "edward", "harry"}
            ,new[] {"sam=99912222", "Not found","harry=12299933"})]
        public void ShouldReturnTheTupleFound(int nb, string[] textReceived, string[] expected, IEnumerable<string> actual)
        {
            $"Given the following text {textReceived}"
                .x(() => {});
            $"When I extract the similar {nb} phonebook"
                .x(() => actual = FilterPhoneBook(nb, textReceived));
            $"Then I expect {actual} be same than {expected}"
                .x(() => Equal(expected.ToList(), actual));
        
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
            var expected = new List<string>()
            {
                "sam=99912222", "Not found", "tom=11122222"
            };
            var lines = new List<string>() {"sam 99912222", "tom 11122222", "harry 12299933", "sam", "henry", "tom"};
            
            var actual = FilterPhoneBook(3, lines.ToList());

            Check.That(actual).HasSize(3);
            Check.That(actual).ContainsExactly(expected);
        }
        
        #endregion
    }
}