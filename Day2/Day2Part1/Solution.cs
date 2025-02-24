namespace Day2Part1;

public class Solution
{
    public int[][] BuildMatrixFromLines(string inputPath)
    {
        var lines = File.ReadAllLines(inputPath);
        var matrix = new int[lines.Length][];
        for (var i = 0; i < lines.Length; i++)
        {
            var lineSplit = lines[i].Split(" ");
            matrix[i] = new int[lineSplit.Length];
            for (var j = 0; j < matrix[i].Length; j++)
            {
                matrix[i][j] = int.Parse(lineSplit[j]);
            }
        }

        return matrix;
    }

    /*
    a report only counts as safe if both of the following are true:
    The levels are either all increasing or all decreasing.
    Any two adjacent levels differ by at least one and at most three
     */
    public int CountSafeRow(string inputPath)
    {
        var matrix = BuildMatrixFromLines(inputPath);
        var valid = 0;
        
        foreach (var line in matrix)
        {
            bool isGrowing = false, isDecreasing = false, isSafe = true;

            for (var i = 1; i < line.Length; i++)
            { 
                if (line.Length <= 2) continue;
                // not safe line
                if (line[i - 1] == line[i] ||
                    Math.Abs(line[i - 1] - line[i]) < 1 ||
                    Math.Abs(line[i - 1] - line[i]) > 3)
                {
                    isSafe = false;
                    break;
                }
                else if (line[i - 1] < line[i]) isGrowing = true;
                else isDecreasing = true;

            }
            
            // if linear and safe 
            if (!(isGrowing && isDecreasing) && isSafe) valid++;
        }

        return valid;
    }
}