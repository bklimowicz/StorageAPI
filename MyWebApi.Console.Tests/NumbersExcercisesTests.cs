using FluentAssertions;

namespace MyWebApi.Console.Tests;

public class NumbersExcercisesTests
{
    public NumbersExcercisesTests()
    {
        
    }

    [Theory]
    [InlineData(12345, new long[] {5, 4, 3, 2, 1})]
    [InlineData(0, new long[] {0})]
    public void ReverseNumber_ReturnsReversedNumberAsArray(long n, long[] expected)
    {
        // Act
        var result = NumbersExcercise.ReverseNumber(n);

        // Assert
        result.Should().Equal(expected);
    }
}