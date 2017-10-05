using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace StringCalculator
{
    public class StringCalculatorShould
    {
        [Fact]
        public void return_0_if_param_is_an_empty_string()
        {
            var sut = new StringCalculator();
            var result = sut.Add(string.Empty);
            result.Should().Be(0);
        }

        [Fact]
        public void return_1_if_param_is_1()
        {
            var sut = new StringCalculator();
            var result = sut.Add("1");
            result.Should().Be(1);
        }

        [Fact]
        public void return_3_if_param_is_12()
        {
            var sut = new StringCalculator();
            var result = sut.Add("1,2");
            result.Should().Be(3);
        }
    }

    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (numbers.Contains(','))
            {
                var splited = numbers.Split(',');
                return splited.Sum(int.Parse);
            }

            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }
            return int.Parse(numbers);
        }
    }
}