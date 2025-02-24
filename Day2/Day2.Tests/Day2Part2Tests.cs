using System;
using System.Collections.Generic;
using System.IO;
using Day2Part2;
using FluentAssertions;
using Xunit;

namespace Day2.Tests;

public class Day2Part2Tests
{
    
    private readonly Solution _solution = new();
    private readonly string _testInputPath = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "test.txt");
    
    [Fact]
    public void Solution_BuildMatrixFromLines_ReturnMatrixOfInt()
    {
        List<List<int>> expected =
        [
            [7, 6, 4, 2, 1],
            [1, 2, 7, 8, 9],
            [9, 7, 6, 2, 1],
            [1, 3, 2, 4, 5],
            [8, 6, 4, 4, 1],
            [1, 3, 6, 7, 9]
        ];
        
        var result = _solution.BuildMatrixFromLines(_testInputPath);
        result.Should().BeEquivalentTo(expected);
    }
    
    [Fact]
    public void Solution_CountSafeRow_ReturnInt()
    {
        const int expected = 4;
        var result = _solution.CountSafeRow(_testInputPath);
        result.Should().Be(expected);
    }
}