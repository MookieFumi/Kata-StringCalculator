using System;
using System.Linq;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

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

        [Theory]
        [InlineData("1,2", 3)]
        [InlineData("1,2,3", 6)]
        [InlineData("1,2,3,4", 10)]
        public void return_3_if_param_is_12_comma_separated(string input, int output)
        {
            var sut = new StringCalculator();
            var result = sut.Add(input);
            result.Should().Be(output);
        }

        [Theory]
        [InlineData("1\n2", 3 )]
        [InlineData("1\n2,3", 6)]
        public void return_6_if_param_is_123_newline_separated(string input, int output)
        {
            var sut = new StringCalculator();
            var result = sut.Add(input);
            result.Should().Be(output);
        }
    }

    public class StringCalculator
    {
        private readonly char[] _separators = { ',', '\n' };

        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }

            var splited = numbers.Split(_separators);
            return splited.Sum(int.Parse);
        }
    }
}