using System.Text;

namespace Day3Part2;

public class Solution
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
        var enabled = true;
        for (var i = 0; i < input.Length - 3; i++)
        {
            _stringBuilder.Append(input[i]);
            _stringBuilder.Append(input[i + 1]);
            _stringBuilder.Append(input[i + 2]);
            _stringBuilder.Append(input[i + 3]);

            if (_stringBuilder.ToString() == "mul(" && enabled)
            {
                var j = i + 4;
                _stringBuilder.Clear();
                // a mult can contain at most two numbers with 3 digit with a comma as a separator (so 7 char)
                for (var x = j; x < j + 8; x++)
                {
                    _stringBuilder.Append(input[x]);
                    if (!char.IsDigit(input[x]) && input[x] != ',')
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
            
            else if (_stringBuilder.ToString() == "do()") enabled = true; 
            else if (_stringBuilder.ToString() == "don'" && !(i + 6 > input.Length))
            {
                if (input[i + 4] == 't' && input[i + 5] == '(' && input[i + 6] == ')') enabled = false;
            }
            _stringBuilder.Clear();
        }

        return multiplicationArr;
    }
    
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