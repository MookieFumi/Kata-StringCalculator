using System;
using System.CodeDom;
using System.Linq;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace StringCalculator
{
    public class StringCalculatorShould
    {
        private readonly StringCalculator _sut;

        public StringCalculatorShould()
        {
            _sut = new StringCalculator();
        }

        [Fact]
        public void return_0_if_param_is_an_empty_string()
        {
            var result = _sut.Add(string.Empty);
            result.Should().Be(0);
        }

        [Fact]
        public void return_1_if_param_is_1()
        {
            var result = _sut.Add("1");
            result.Should().Be(1);
        }

        [Theory]
        [InlineData("1,2", 3)]
        [InlineData("1,2,3", 6)]
        [InlineData("1,2,3,4", 10)]
        public void return_3_if_param_is_12_comma_separated(string input, int output)
        {
            var result = _sut.Add(input);
            result.Should().Be(output);
        }

        [Theory]
        [InlineData("1\n2", 3)]
        [InlineData("1\n2,3", 6)]
        public void return_6_if_param_is_123_newline_separated(string input, int output)
        {
            var result = _sut.Add(input);
            result.Should().Be(output);
        }

        [Fact]
        public void throws_exception_if_there_is_a_negative_number()
        {
            Assert.Throws<ArgumentException>(() => _sut.Add("-5"));
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

            var splited = numbers.Split(_separators).Select(int.Parse).ToList();
            if (splited.Any(p => p < 0))
            {
                throw new ArgumentException();
            }

            return splited.Sum();
        }
    }
}