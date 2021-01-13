using System;

namespace VariablesCS
{
  class Program
  {
    static void Main(string[] args)
    {
      int numberOfCupsOfCoffee = 2;
      string fullName = "Jason L Perry";
      string today = "January 12, 2021";

      Console.WriteLine("On {2}, {1} drank {0} cups of coffee.", numberOfCupsOfCoffee, fullName, today);
      Console.WriteLine($"On {today}, {fullName} drank {numberOfCupsOfCoffee} cups of coffee.");

      string userName = "";

      while (userName.Length == 0) {
        Console.Write("What is your name? ");
        userName = Console.ReadLine();
        if (userName.Length == 0) {
          Console.WriteLine("I really need to know your name first.");
        }

        if (userName == "Alice") {
          Console.WriteLine("Why, sometimes I've believed as many as six impossible things before breakfast.");
        }
      }

      Console.Write("How many sodas do you drink each day? ");
      int numberOfSodas = int.Parse(Console.ReadLine());
      Console.WriteLine($"Hello, {userName}, I understand you drink {numberOfSodas} sodas each day, try drinking only {numberOfSodas / 2} for a happy life.");

      Console.Write("Give me a number, please: ");
      string firstNumberAsString = Console.ReadLine();

      Console.Write("Can you give me a another number: ");
      string secondNumberAsString = Console.ReadLine();

      double firstOperand = double.Parse(firstNumberAsString);
      double secondOperand = double.Parse(secondNumberAsString);

      double sum = firstOperand + secondOperand;
      Console.WriteLine("The sum of " + firstOperand + " and " + secondOperand + " is " + sum);
    }
  }
}

