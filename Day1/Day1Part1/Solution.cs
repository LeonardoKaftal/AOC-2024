namespace Day1Part1;

public class Solution
{
    public Tuple<List<int>, List<int>> ReadLines(string inputPath)
    {
        List<int> firstColumn = [];
        List<int> secondColumn = [];
        
        foreach(var line in File.ReadLines(inputPath))
        {
            var firstNumber = line.Split("   ")[0];
            var secondNumber = line.Split("   ")[1];
            firstColumn.Add(int.Parse(firstNumber));
            secondColumn.Add(int.Parse(secondNumber));
        }
        
        return new Tuple<List<int>, List<int>>(firstColumn,secondColumn);
    }

    public int CountScoreForPairs(string inputPath)
    {
        var result = 0;
        var (firstList, secondList) = ReadLines(inputPath);
        QuickSort(firstList, 0, firstList.Count - 1);
        QuickSort(secondList, 0, firstList.Count - 1);

        for (var i = 0; i < firstList.Count; i++)
        {
            result += Math.Abs(firstList[i] - secondList[i]);
        }
        return result;
    }

    public void QuickSort(List<int> input, int start, int end)
    {
        if (start >= end) return;
        var i = start - 1;
        var pivot = input[end];

        for (var j = start; j < end; j++)
        {
            if (input[j] < pivot)
            {
                i++;
                (input[i], input[j]) = (input[j], input[i]);
            }
        }

        i++;
        (input[i], input[end]) = (input[end], input[i]);
        
        QuickSort(input, start, i -1);
        QuickSort(input, i + 1, end);
    }
}