using System.Text;
namespace Day4Part1;
public class Solution
{
    public string[] ReadInput(string inputPath)
    {
        return File.ReadLines(inputPath).ToArray();
    }
    
    public int CountXmas(string inputPath)
    {
        var input = ReadInput(inputPath);
        var result = 0;
        
        // count horizontally
        foreach (var line in input)
        {
            result += CountHoriz(line);
        }
        
        // count vertically 
        for (var j = 0; j < input[0].Length; j++)
        {
            result += CountVert(j, input);
        }
        
        // count diagonally (top-left to bottom-right)
        for (var i = 0; i < input.Length; i++)
        {
            if (i > 0) // Skip (0,0) as it will be counted in the next loop
                result += CountDiag(i, 0, input);
        }
        for (var j = 0; j < input[0].Length; j++)
        {
            result += CountDiag(0, j, input);
        }
        
        // count diagonally (top-right to bottom-left)
        for (var i = 0; i < input.Length; i++)
        {
            result += CountDiagReverse(i, input[0].Length - 1, input);
        }
        for (var j = 0; j < input[0].Length; j++)
        {
            if (j < input[0].Length - 1) // Skip the top-right corner as it's already counted
                result += CountDiagReverse(0, j, input);
        }
        
        return result;
    }
    
    public int CountHoriz(string line)
    {
        var result = 0;
        
        for (var i = 0; i <= line.Length - 4; i++)
        {
            // Forward check
            if (line[i] == 'X' && line[i+1] == 'M' && line[i+2] == 'A' && line[i+3] == 'S')
                result++;
            
            // Backward check
            if (line[i] == 'S' && line[i+1] == 'A' && line[i+2] == 'M' && line[i+3] == 'X')
                result++;
        }
        
        return result;
    }
    
    public int CountVert(int j, string[] arr)
    {
        var result = 0;
        
        for (var i = 0; i <= arr.Length - 4; i++)
        {
            // Forward check
            if (arr[i][j] == 'X' && arr[i+1][j] == 'M' && arr[i+2][j] == 'A' && arr[i+3][j] == 'S')
                result++;
            
            // Backward check 
            if (arr[i][j] == 'S' && arr[i+1][j] == 'A' && arr[i+2][j] == 'M' && arr[i+3][j] == 'X')
                result++;
        }
        
        return result;
    }
    
    public int CountDiag(int i, int j, string[] arr)
    {
        var result = 0;
        
        while (i <= arr.Length - 4 && j <= arr[0].Length - 4)
        {
            // Forward check
            if (arr[i][j] == 'X' && arr[i+1][j+1] == 'M' && arr[i+2][j+2] == 'A' && arr[i+3][j+3] == 'S')
                result++;
            
            // Backward check
            if (arr[i][j] == 'S' && arr[i+1][j+1] == 'A' && arr[i+2][j+2] == 'M' && arr[i+3][j+3] == 'X')
                result++;
            
            i++;
            j++;
        }
        
        return result;
    }
    
    public int CountDiagReverse(int i, int j, string[] arr)
    {
        var result = 0;
        
        while (i <= arr.Length - 4 && j >= 3)
        {
            // Forward check
            if (arr[i][j] == 'X' && arr[i+1][j-1] == 'M' && arr[i+2][j-2] == 'A' && arr[i+3][j-3] == 'S')
                result++;
            
            // Backward check
            if (arr[i][j] == 'S' && arr[i+1][j-1] == 'A' && arr[i+2][j-2] == 'M' && arr[i+3][j-3] == 'X')
                result++;
            
            i++;
            j--;
        }
        
        return result;
    }
}
