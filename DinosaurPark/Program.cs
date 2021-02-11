using System;
using System.Collections.Generic;

namespace DinosaurPark
{
  class Dinosaur 
  {
    string Name;

    public Dinosaur(string name)
    {
      this.Name = name; 
    }
    public string Description()
    {
      return $"This dino's name is {this.Name}";
    }
  }
  
  class Program
  {
    static List<Dinosaur> Dinos = new List<Dinosaur>() 
    { 
      new Dinosaur("Triceratops"),
      new Dinosaur("Velociraptor"), 
    };
    static void Main(string[] args)
    {
      Console.WriteLine(@"
      
              ~~ Welcome to Dino Park™ ~~
                    
                    /~~~~~~~~~~~~\_
 _+=+_             _[~  /~~~~~~~~~~~~\_
{""""|""""}         [~~~    [~   /~~~~~~~~~\_
 """""":-'~[~[~""~[~  ((++     [~  _/~~~~~~~~\_
      '=_   [    ,==, ((++    [    /~~~~~~~\-~~~-.
         ~-_ _=+-(   )/   ((++  .~~~.[~~~~(  {@} \`.
                 /   }\ /     (     }     (   .   ''}
                (  .+   \ /  //     )    / .,  """"""""/
                \\  \     \ (   .+~~\_  /.= /'""""""""
                <""_V_"">      \\  \    ~~~~~~\\  \
                              \\  \          \\  \
                              <""_V_"">        <""_V_"">

");

      int menuChoice;
      do
      {
        menuChoice = PromptForInt(@"Please choose one of the following options:

1) View        List all Dino
2) Add         Create a new Dino
3) Remove      Remove a Dino
4) Transfer    Move a Dino to a new enclosure
5) Summary     Overview of Dino Park™
6) Quit        Exit the program");

        // Console.WriteLine($"You picked: {menuChoice}");

        switch (menuChoice)
        {
          case 1:
            ViewDinos();
            break;
          case 2:
            AddDino();
            break;
          case 3:
            RemoveDino();
            break;
          case 4:
            TransferDino();
            break;
          case 5:
            ParkSummary();
            break;
          case 6:
            break;
          default:
            Console.WriteLine("That is not a valid option.");
            break;
        }
        Console.Clear();
      } while (menuChoice != 6);
      
      Console.WriteLine("Goodbye!");
    }
    
    static void ViewDinos()
    {
      Console.Clear();
      Console.WriteLine("------------------------\n~~.*.VIEW ALL DINOS.*.~~\n------------------------\n");
      foreach (var dino in Dinos)
      {
        Console.WriteLine(dino.Description());
      }
      Console.Write("\nPress any key to continue...");
      Console.ReadKey();
    }
    
    static void AddDino()
    {
      Console.WriteLine("You picked 'add'");
    }

    static void RemoveDino()
    {
      Console.WriteLine("You picked 'remove'");
    }

    static void TransferDino()
    {
      Console.WriteLine("You picked 'transfer'");
    }

    static void ParkSummary()
    {
      Console.WriteLine("You picked 'summary'");
    }

    static void PrintTitle(string message)
    {
      Console.WriteLine("TODO: IMPLEMENT ME");
    }

    static int PromptForInt(string message)
    {
      Console.WriteLine(message);
      var userInputAsInteger = 0;
      while (userInputAsInteger == 0)
      {
        try
        {
          Console.Write("\n> ");
          var userInput = Console.ReadLine();
          userInputAsInteger = int.Parse(userInput);
        }
        catch (System.FormatException) {
          Console.WriteLine("I'm sorry, I didn't understand that. Can you try again?");
        }
      }
      return userInputAsInteger;
    }
  }
}
