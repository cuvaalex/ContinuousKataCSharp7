using System;
using Xunit;
using static Xunit.Assert;

namespace Day4
{
    class Person {
        public int age;
        public Person(int initialAge) => Age = initialAge;

        private int Age
        {
            set
            {
                if (value < 0)
                {
                    age = 0;
                    Console.WriteLine("Age is not valid, setting age to 0.");
                }
                else
                {
                    age = value;    
                }
                
            }
        }

        public void amIOld() {
            Console.WriteLine(IamOldMessage()); 
        }

        protected internal String IamOldMessage()
        {
            if (age < 13)
            {
                return "You are young.";    
            }else if (age < 18)
            {
                return "You are a teenager.";
            }

            return "You are old.";
        }

        public void yearPasses()
        {
            age++;
        }
    }
    public class UnitTest1 {

        [Fact]
        public void shouldReturnAgeTo0IfInitialAgeIsNegatif()
        {
            const int expected = 0;
            var actual = new Person(-1).age;
            
            Equal(expected, actual);
        }
        
        [Theory]
        [InlineData(0)]
        [InlineData(10)]
        public void shouldReturnInitialAgeIfInitialAgeIsNonNegatif(int expected)
        {
            var actual = new Person(expected).age;
            
            Equal(expected, actual);
        }

        [Fact]
        public void shouldIncreaseAgeByOne()
        {
            const int expected = 3;
            const int initialAge = 2;
            
            var person = new Person(initialAge);
            person.yearPasses();
            var actual = person.age;
            
            Equal(expected, actual);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(12)]
        public void shouldReturnImYoungIfAgeLessThan13(int initialAge)
        {
            const String expected = "You are young.";
            
            var person = new Person(initialAge);
            var actual = person.IamOldMessage();
            
            Equal(expected, actual);
        }

        [Theory]
        [InlineData(13)]
        [InlineData(15)]
        [InlineData(17)]
        public void shouldReturnYouAreATeenagerIfAgeEqualOrGreatherThan13AndLessThan18(int initialAge)
        {
            const String expected = "You are a teenager.";
            
            var person = new Person(initialAge);
            var actual = person.IamOldMessage();
            
            Equal(expected, actual);
        }

        [Theory]
        [InlineData(18)]
        [InlineData(30)]
        [InlineData(100)]
        public void shouldReturnYouAreOldIfAgeEqualOrGreatherThan18(int initialAge)
        {
            const String expected = "You are old.";
            
            var person = new Person(initialAge);
            var actual = person.IamOldMessage();
            
            Equal(expected, actual);
        }

    }
    
}