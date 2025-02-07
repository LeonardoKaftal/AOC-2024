using System;
using System.Collections.Generic;
using System.IO;
using Day1Part1;
using FluentAssertions;
using JetBrains.Annotations;
using Xunit;

namespace Day1.Tests;


[TestSubject(typeof(Solution))]
public class Day1Part1Tests
{
    private readonly Solution _solution = new Solution();
    private readonly string _testInputPath = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "input1.txt");
    
    [Fact]
    public void Solution_ReadLines_ReturnTupleOfList() 
    {
        var result = _solution.ReadLines(_testInputPath);
        List<int> list1 = [3,4,2,1,3,3];
        List<int> list2 = [4,3,5,3,9,3];
        var expected = new Tuple<List<int>, List<int>>(list1, list2);
        expected.Should().BeEquivalentTo(result);
    }

    [Fact]
    public void Solution_QuickSort_ReturnVoid()
    {
        List<int> input = [8,2,4,7,1,3,9,6,5];
        List<int> expected = [1,2,3,4,5,6,7,8,9];
        
        _solution.QuickSort(input, 0,input.Count - 1);
        input.Should().Equal(expected);
        
    }
    
    [Fact]
    public void Solution_CountScoreForPairs_ReturnInt()
    {
        const int expected = 11;
        var result = _solution.CountScoreForPairs(_testInputPath);
        expected.Should().Be(result);
    }
}