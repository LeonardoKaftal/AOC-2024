using System.Text;
using static System.Char;

namespace Day3Part1;

public class Solution()
{
    private readonly StringBuilder _stringBuilder = new StringBuilder();
    public string ReadInput(string inputPath)
    {
        var result = File.ReadAllText(inputPath);
        return result.Replace("\n", "");
    }
    
    public List<string> FindValidSubstring(string inputPath)
    {
        var input = ReadInput(inputPath);
        List<string> multiplicationArr = [];
        for (var i = 0; i < input.Length - 3; i++)
        {
            _stringBuilder.Append(input[i]);
            _stringBuilder.Append(input[i + 1]);
            _stringBuilder.Append(input[i + 2]);
            _stringBuilder.Append(input[i + 3]);

            if (_stringBuilder.ToString() == "mul(")
            {
                var j = i + 4;
                _stringBuilder.Clear();
                // a mult can contain at most two numbers with 3 digit with a comma as a separator (so 7 char)
                for (var x = j; x < j + 8; x++)
                {
                    _stringBuilder.Append(input[x]);
                    if (!IsDigit(input[x]) && input[x] != ',')
                    {
                       break; 
                    }
                }

                var toAdd = _stringBuilder.ToString();
                if (toAdd[^1] == ')')
                {
                    // remove )
                    toAdd = toAdd.Remove(toAdd.Length - 1, 1); 
                    multiplicationArr.Add(toAdd);
                }
            }

            _stringBuilder.Clear();
        }

        return multiplicationArr;
    }
    
    // check on input
    public int Multiply(string inputPath)
    {
        var multArr = FindValidSubstring(inputPath);
        var counter = 0;
        foreach (var mult in multArr)
        {
            if (!mult.Contains(','))
            {
                continue;
            }
            var splitted = mult.Split(",");
            counter += int.Parse(splitted[0]) * int.Parse(splitted[1]);
        }

        return counter;
    }
}