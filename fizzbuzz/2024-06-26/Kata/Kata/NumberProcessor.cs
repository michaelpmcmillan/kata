namespace Kata;

public class NumberProcessor : INumberProcessor
{
    public string Get(int i)
    {
        var output = $"";
        if (i % 3 == 0) output += "Fizz";
        if (i % 5 == 0) output += "Buzz";

        if (string.IsNullOrEmpty(output))
        {
            return i.ToString();
        }

        return output;
    }
}

public interface INumberProcessor
{
    string Get(int i);
}
