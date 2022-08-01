// See https://aka.ms/new-console-template for more information
using FizzBuzz;

Console.WriteLine("Hello, World!");

var itemGenerator = new FizzBuzzItemGenerator();

foreach(var item in new FizzBuzzResultGenerator(itemGenerator).Generate(1, 100))
{
    Console.WriteLine(item.ToString());
}