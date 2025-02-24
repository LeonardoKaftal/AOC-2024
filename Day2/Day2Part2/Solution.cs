namespace Day2Part2;

public class Solution
{
     public List<List<int>> BuildMatrixFromLines(string inputPath)
     {
        var lines = File.ReadAllLines(inputPath);
        var matrix = new List<List<int>>();
        
        for (var i = 0; i < lines.Length; i++)
        {
            var lineSplit = lines[i].Split(" ");
            matrix.Add([]);
            foreach (var number in lineSplit)
            {
                matrix[i].Add(int.Parse(number));
            }
        }

        return matrix;
     }
     
    /*
    a report only counts as safe if both of the following are true:
    The levels are either all increasing or all decreasing.
    Any two adjacent levels differ by at least one and at most three
    If the row is found to be invalid, only for the first invalid member of the sequence, it can be ignored (so it will be invalid if more than one)
     */
    public int CountSafeRow(string inputPath)
    {
        var matrix = BuildMatrixFromLines(inputPath);
        var validRow = 0;
        foreach (var line in matrix)
        {
            if (IsValid(line, true))
            {
                validRow++;
            }
        }
        return validRow;
    }

    
    private bool IsValid(List<int> line, bool firstTime)
    {
        bool isGrowing = false, isDecreasing = false; 
        
        for (var i = 1; i < line.Count; i++)
        {
            var prev = line[i - 1];
            var current = line[i];
            var diff = Math.Abs(prev - current);

            if (current < prev) isDecreasing = true;
            else if (current > prev) isGrowing = true;

            if (diff is < 1 or > 3 || (isDecreasing && isGrowing))
            {
                if (firstTime)
                {
                    for (int j = 0; j < line.Count; j++)
                    {
                        var modifiedLine = new List<int>(line);
                        modifiedLine.RemoveAt(j);
                        if (IsValid(modifiedLine, false))
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
        }

        return true; 
    }
}