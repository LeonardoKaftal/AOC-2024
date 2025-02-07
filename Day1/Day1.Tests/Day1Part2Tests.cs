using System;
using System.Collections.Generic;
using System.IO;
using Day1Part2;
using FluentAssertions;
using JetBrains.Annotations;
using Xunit;

namespace Day1.Tests;

[TestSubject(typeof(Solution))]
public class Day1Part2Tests
{
    private readonly Solution _solution = new();
    private readonly string _inputPath = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "input2.txt");

    
    [Fact]
    public void Solution_ReadLines_ReturnTupleOfList() 
    {
        var result = _solution.ReadLines(_inputPath);
        List<string> list1 = ["3","4", "2", "1", "3", "3"];
        List<string> list2 = ["4", "3", "5", "3", "9", "3"];
        var expected = new Tuple<List<string>, List<string>>(list1, list2);
        expected.Should().BeEquivalentTo(result);
    }

    [Fact]
    public void Solution_AddSimilarityScore_ReturnInt()
    {
        var result = _solution.AddSimilarityScore(_inputPath);
        const int expected = 31;
        result.Should().Be(expected);
    }
}