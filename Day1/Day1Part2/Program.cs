namespace Day1Part2;

public static class Program
{
    public static void Main(string[] args)
    {
        var solution = new Solution();
        var result = solution.AddSimilarityScore("input.txt");
        Console.WriteLine(result);
    }
}