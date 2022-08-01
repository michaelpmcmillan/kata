namespace FizzBuzz;

public class FizzBuzzItemGenerator : IFizzBuzzItemGenerator
{
    public string GetItem(int number)
    {
        return number % 3 == 0
            ? "Fizz"
            : number.ToString();
    }
}
