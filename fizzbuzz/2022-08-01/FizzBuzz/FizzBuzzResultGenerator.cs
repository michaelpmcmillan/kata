namespace FizzBuzz;

public class FizzBuzzResultGenerator
{
    public IEnumerable<string> Generate()
    {
        return Enumerable.Range(1, 100).Select(number => number.ToString());
    }
}
