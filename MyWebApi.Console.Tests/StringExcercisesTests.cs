using System;
using FluentAssertions;

namespace MyWebApi.Console.Tests;

public class StringExcercisesTests
{
    public StringExcercisesTests()
    {
    }

    [Fact]
    public void GetReverseString_WhenStringIsEmpty_ThrowsArgumentException()
    {
        // Arrange
        var str = string.Empty;

        // Act
        Action act = () => StringExcercises.GetReverseString(str);

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void GetReverseString_WhenStringIsValid_ReturnsReversedString()
    {
        // Arrange
        const string str = "Hello";

        // Act
        var result = StringExcercises.GetReverseString(str);

        // Assert
        result.Should().Be("olleH");
    }

    [Theory]
    [InlineData(new string[] { }, "no one likes this")]
    [InlineData(new string[] { "Peter" }, "Peter likes this")]
    [InlineData(new string[] { "Jacob", "Alex" }, "Jacob and Alex like this")]
    [InlineData(new string[] { "Max", "John", "Mark" }, "Max, John and Mark like this")]
    [InlineData(new string[] { "Alex", "Jacob", "Mark", "Max" }, "Alex, Jacob and 2 others like this")]
    public void GetLikesString_WhenNamesAreValid_ReturnsLikesString(string[] names, string expectedString)
    {
        var result = StringExcercises.Likes(names);

        result.Should().Be(expectedString);
    }
}