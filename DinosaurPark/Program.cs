using System;
using System.Collections.Generic;
using System.Linq;

namespace DinosaurPark
{
  class Dinosaur 
  {
    public string Name;
    public string DietType;
    public int Weight;
    public int EnclosureNumber;
    public DateTime WhenAcquired; 

    public Dinosaur()
    {
      this.WhenAcquired = DateTime.Now;
    }

    public string Description()
    {
      return $"This dino's name is {this.Name}. He was born at {this.WhenAcquired}. Be aware of what you feed {this.Name} as he is a {this.DietType} or you might end up killing him! Don't feed him too much as he currently weighs {this.Weight} pounds, which is ideal. Don't forget to visit him in {this.EnclosureNumber} exhibit.";
    }
  }
  
  class Program
  {
    static List<Dinosaur> Dinos = new List<Dinosaur>() 
    {
      new Dinosaur()
      {
        Name = "Triceratops",
        DietType = "Herbivore",
        Weight = 23400,
        EnclosureNumber = 1
      },
      new Dinosaur()
      {
        Name = "T-Rex",
        DietType = "Carnivore",
        Weight = 76300,
        EnclosureNumber = 2
      }
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
      WaitForKeyPress();
    }

    static void AddDino()
    {
      Console.Clear();
      {
        Console.WriteLine("You picked 'add'");
        Console.WriteLine("Please tell me your Dino's name.");
        var newDinoName = Console.ReadLine();

        Console.WriteLine("Is this Dino a Carnivore or Herbivore? ");
        var newDinoDiet = Console.ReadLine();

        Console.WriteLine("How much does this Dino weigh (in pounds)?");
        var newDinoWeight = int.Parse(Console.ReadLine());

        Console.WriteLine("Into which enclosure number would you like to place this Dino?");
        var newDinoEnclosure = int.Parse(Console.ReadLine());

        
        var newDino = new Dinosaur()
        {
            Name = newDinoName,
            DietType = newDinoDiet,
            Weight = newDinoWeight,
            EnclosureNumber = newDinoEnclosure,
        };
        Dinos.Add(newDino);
      }
      WaitForKeyPress();
    }
    static void RemoveDino()
    {
      Console.WriteLine("You picked 'remove'");
      Console.WriteLine("What is the name of the Dino you want to remove?");
      var dinoNameToRemove = Console.ReadLine();
      var dinosRemoved = Dinos.RemoveAll(dino => dino.Name == dinoNameToRemove);
      Console.WriteLine($"Removed {dinosRemoved} dino(s) named {dinoNameToRemove}.");
      WaitForKeyPress();
    }

    static void TransferDino()
    {
      Console.WriteLine("You picked 'transfer'");
      Console.WriteLine("What is the name of the Dino you want to transfer?");
      var dinoNameToTransfer = Console.ReadLine();
      Console.WriteLine($"Which exhibit would you like to transfer {dinoNameToTransfer} to?");
      var exhibittotransferto = int.Parse(Console.ReadLine());
      Dinos.Find(dino => dino.Name == dinoNameToTransfer).EnclosureNumber = exhibittotransferto;
      WaitForKeyPress();
      
    }

    static void ParkSummary()
    {
      Console.WriteLine("You picked 'summary'");
      var herbivores = Dinos.Where(dino => dino.DietType == "Herbivore");
      var carnivores = Dinos.Where(dino => dino.DietType == "Carnivore");

      Console.WriteLine($"There are {herbivores.Count()} Herbivores, and {carnivores.Count()} Carnivores in the park.");
      WaitForKeyPress();
    }

    static void PrintTitle(string message)
    {
      Console.WriteLine("TODO: IMPLEMENT ME");
    }

    static void WaitForKeyPress()
    {
      Console.Write("\nPress any key to continue...");
      Console.ReadKey();
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
