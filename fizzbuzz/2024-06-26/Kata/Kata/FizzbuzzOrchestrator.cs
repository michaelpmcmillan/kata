namespace Kata;

/*
 * Write a program that prints one line for each number from 1 to 100
 * For multiples of three print Fizz instead of the number
 * For the multiples of five print Buzz instead of the number
 * For numbers which are multiples of both three and five print FizzBuzz instead of the number
 */

public class FizzbuzzOrchestrator(INumberProcessor numberProcessor)
{
    public IEnumerable<string> Execute(int start, int count)
    {
        var items = new List<string>();

        for (int i = start; i <= count; i++)
        {
            var item = numberProcessor.Get(i);
            items.Add(item);
        }

        return items;
    }
}
