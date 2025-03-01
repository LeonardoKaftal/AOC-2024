using System;
using System.IO;
using Day4Part1;
using FluentAssertions;
using JetBrains.Annotations;
using Xunit;

namespace Day4.Tests;

[TestSubject(typeof(Solution))]
public class Day4Part1Tests
{
    private readonly Solution _solution = new Solution();
    private readonly string _testInputPath = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "test.txt");
    
    [Fact] 
    public void Solution_ReadInput_ReturnArrayOfString()
    {
        string[] expected = [
            "MMMSXXMASM",
            "MSAMXMSMSA",
            "AMXSXMAAMM",
            "MSAMASMSMX",
            "XMASAMXAMM",
            "XXAMMXXAMA",
            "SMSMSASXSS",
            "SAXAMASAAA",
            "MAMMMXMMMM",
            "MXMXAXMASX"
        ];
        var result = _solution.ReadInput(_testInputPath);
        result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void Solution_CountXmas_ReturnInt()
    {
        var result = _solution.CountXmas(_testInputPath);
        const int expected = 18;
        result.Should().Be(expected);
    }

    [Fact]
    public void Solution_IterHoriz_ReturnInt()
    {
        const string input = "XXMMXMASXXMSAMXXMXMX";
        const int expected = 2;
        var result = _solution.CountHoriz(input);
        result.Should().Be(expected);
    }

    [Fact]
    public void Solution_CountVert_ReturnInt()
    {
        string[] arr = [
            "XAC", 
            "MXF", 
            "ADX", 
            "SMX", 
            "SMX", 
            "AMM", 
            "MXX", 
            "XMM"];
        const int expected = 2;
        var result = _solution.CountVert(0, arr);
        result.Should().Be(expected);
    }

    [Fact]
    public void Solution_CountDiag_ReturnInt()
    {
        string[] arr =
        [
            "XMASMMMXWM",
            "UMAODJSEIJ",
            "DXASDJHSJD",
            "SJDSJDKDJD",
            "SSSSSFDKFK",
            "CCCCCADFFG",
            "DDDDDDMDFS",
            "AWWWWWSXMM",
        ];

        var expected = 2;
        var result = _solution.CountDiag(0, 0, arr);
        result.Should().Be(expected);
    }
}