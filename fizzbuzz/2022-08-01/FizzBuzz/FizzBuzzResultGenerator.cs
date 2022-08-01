namespace FizzBuzz;

public class FizzBuzzResultGenerator
{
    private readonly IFizzBuzzItemGenerator _itemGenerator;

    public FizzBuzzResultGenerator(IFizzBuzzItemGenerator itemGenerator)
    {
        _itemGenerator = itemGenerator;
    }

    public IEnumerable<string> Generate(int start, int count)
    {
        return Enumerable.Range(start, count)
            .Select(number => _itemGenerator.GetItem(number));
    }
}
