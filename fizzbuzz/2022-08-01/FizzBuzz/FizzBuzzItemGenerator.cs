namespace FizzBuzz;

public class FizzBuzzItemGenerator : IFizzBuzzItemGenerator
{
    public string GetItem(int number)
    {
        var result = GetFizz(number) + GetBuzz(number);
        return result == ""
            ? number.ToString()
            : result;
    }

    private string GetFizz(int number) => number % 3 == 0 ? "Fizz" : "";
    private string GetBuzz(int number) => number % 5 == 0 ? "Buzz" : "";
}
