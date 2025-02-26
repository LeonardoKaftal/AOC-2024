using System;
using System.Collections.Generic;
using System.IO;
using FluentAssertions;
using JetBrains.Annotations;
using Xunit;

namespace Day3Part1.Tests;

[TestSubject(typeof(Solution))]
public class Day3Part1Tests
{
    private readonly Solution _solution = new();
    private static readonly string BasePath = Path.Combine(AppContext.BaseDirectory, "..", "..", "..");
    private readonly string _testInputPath = Path.Combine(BasePath, "test.txt");
    private readonly string _secondTestInputhPath = Path.Combine(BasePath, "test2.txt");

    [Fact]
    public void Solution_ReadInput_ReturnString()
    {
        var result = _solution.ReadInput(_testInputPath);
        var expected = "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))";
        result.Should().Be(expected);
        // second test
        expected = "mul(168,87)}*:mul(911,800)(%,)where()#&&$mul(734,19)" +
                   "?when()why(){$:?mul(829,495)do()mul(724,312){;^mul(520,383) mul(137,485)";
        result = _solution.ReadInput(_secondTestInputhPath);
        result.Should().Be(expected);
    }

    [Fact]
    public void Solution_FindValidSubstring_ReturnListOfString()
    {
        var result = _solution.FindValidSubstring(_testInputPath);
        List<string> expected = ["2,4", "5,5", "11,8", "8,5"];
        result.Should().BeEquivalentTo(expected);
        // second test
        result = _solution.FindValidSubstring(_secondTestInputhPath);
        expected = ["168,87", "911,800", "734,19", "829,495", "724,312",
            "520,383", "137,485"];
        result.Should().Equal(expected);
    }

    [Fact]
    public void Solution_Multiply_ReturnInt()
    {
        var result = _solution.Multiply(_testInputPath);
        var expected = 161;
        result.Should().Be(expected);
        // second test
        result = _solution.Multiply(_secondTestInputhPath);
        expected = 1659210;
        result.Should().Be(expected);
    }
}