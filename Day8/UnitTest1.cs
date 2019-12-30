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
        public IEnumerable<string> FilterPhoneBook(IReadOnlyCollection<string> phoneBooks, IReadOnlyCollection<string> filter)
        {
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
            ,new[] {"sam=99912222", "tom=11122222", "harry=12299933"}
            ,new[] {"sam", "edward", "harry"}
            ,new[] {"sam=99912222", "Not found","harry=12299933"})]
        public void ShouldReturnTheTupleFound(int nb, string[] phones, string[] names, string[] expected, IEnumerable<string> actual)
        {
            $"Given the following phones {phones}"
                .x(() => {});
            $"And the following names {names}"
                .x(() => { });
            $"When I extract the similar phones"
                .x(() => actual = FilterPhoneBook(phones, names));
            $"Then I expect {actual} be same than {expected}"
                .x(() =>
                {
                    Check.That(actual).CountIs(nb);
                    Check.That(actual).Equals(expected);
                });
        
        }
        
        [Fact]
        public void ShouldExtractThe2PhoneBook()
        {
            var expected = new List<string>()
            {
                "sam=99912222", "Not found", "tom=11122222"
            };
            var phones = new List<string>() {"sam=99912222", "tom=11122222", "harry=12299933"};
            var names = new List<string>() {"sam", "henry", "tom"};
            
            var actual = FilterPhoneBook(phones, names);

            Check.That(actual).HasSize(3);
            Check.That(actual).ContainsExactly(expected);
        }
        
        #endregion
    }
}