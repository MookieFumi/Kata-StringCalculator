using System;
using System.Threading;
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
    }

    public class StringCalculator
    {
        public int Add(string numbers)
        {
            return 0;
        }
    }
}
