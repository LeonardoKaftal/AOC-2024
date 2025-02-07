namespace Day1Part2;

public class Solution
{
    public Tuple<List<string>, List<string>> ReadLines(string inputPath)
    {
        List<string> firstColumn = [];
        List<string> secondColumn = [];
        
        foreach(var line in File.ReadLines(inputPath))
        {
            var firstNumber = line.Split("   ")[0];
            var secondNumber = line.Split("   ")[1];
            firstColumn.Add(firstNumber);
            secondColumn.Add(secondNumber);
        }
        
        return new Tuple<List<string>, List<string>>(firstColumn,secondColumn);
    }


    public int AddSimilarityScore(string inputPath)
    {
        var (firstList, secondList) = ReadLines(inputPath);
        var count = 0;
        foreach (var toFind in firstList)
        {
            var counted = secondList.FindAll((num => toFind == num)).Count;
            count += int.Parse(toFind) * counted;
        }
        return count;
    }
    
}