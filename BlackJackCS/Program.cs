using System;
using System.Collections.Generic;

namespace BlackJackCS
{
  class Card
  {
    // STATE or DATA
    public string Suit; // <- a property.
    public string Face;
    public int Value;

    // BEHAVIOR...

    // The constructor:
    public Card(string face, string suit, int value) {
      this.Face = face;
      this.Suit = suit;
      this.Value = value;
    }

    override public string ToString() {
      return $"{this.Face} of {this.Suit}";
    }
  }
  
  class Deck
  {
    public List<Card> Cards;

    public Deck()
    {
      this.Cards = new List<Card>();
      var suits = new List<string> { "Clubs", "Diamonds", "Hearts", "Spades" };
      var faces = new List<string> { "Ace", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King" };
      foreach (var suit in suits)
      {
        for (int i = 0; i < faces.Count; i++)
        {
          var face = faces[i];
          var value = i < 9 ? i + 1 : 10;
          this.Cards.Add(new Card(face, suit, value));
        }
      }
    }

    public void Shuffle()
    {
      var numberOfCards = this.Cards.Count;
      var randomNumberGenerator = new Random();

      for (var rightIndex = numberOfCards -1; rightIndex >= 1; rightIndex--)
      {
        var leftIndex = randomNumberGenerator.Next(rightIndex);
        var leftCard = this.Cards[leftIndex];
        var rightCard = this.Cards[rightIndex];
        this.Cards[rightIndex] = leftCard;
        this.Cards[leftIndex] = rightCard;      
      }
      
    }
    public Card Deal()
    {
      var card = this.Cards[0];
      this.Cards.RemoveAt(0);
      return card;
    }
  }
  
  class Hand  
  {
    List<Card> Cards = new List<Card>();

    public int Score()
    {
      int total = 0;
      foreach (var card in this.Cards)
      {
        total += card.Value;
      }
      return total;
    }

    public void Add(Card card)
    {
      this.Cards.Add(card);
    }

    public void Print()
    {
      foreach (var card in this.Cards)
      {
        Console.WriteLine($"{card} ({card.Value})");
      }
    }
  }

  class Program
  {
    static void Main(string[] args)
    {
      while (true)
      {
        var deck = new Deck();
        deck.Shuffle();

        // Deal two cards to the House
        var house = new Hand();
        house.Add(deck.Deal());
        house.Add(deck.Deal());

        // Deal two cards to the Player
        var player = new Hand();
        player.Add(deck.Deal());
        player.Add(deck.Deal());

        // Print Player cards
        Console.WriteLine("Your hand is:");
        player.Print();

        while (true)
        {
          // Ask Player to "hit" or "stay"
          Console.WriteLine("Would you like to (h)it or (s)tay?");
          var response = Console.ReadLine();
          if (response.ToLower().StartsWith("h"))
          {
            Console.WriteLine("You HIT");
            player.Add(deck.Deal());

            // If `<Hand>` score > 21 Player "busts"
            if (player.Score() >= 21) break;
          }
          else
          {
            Console.WriteLine("You Stayed");
            break;
          }
        }
        Console.WriteLine($"The player's hand scores: {player.Score()}");
        if (player.Score() > 21)
        {
          Console.WriteLine("Sorry, you lose.");
        }
        else
        {
          Console.WriteLine("Dealer Plays.");
          Console.WriteLine($"The house's hand scores: {house.Score()}");
          house.Print();
          // - If House `<Hand>` < 17
          while (house.Score() < 17)
          {
            var newCard = deck.Deal();
            house.Add(newCard);
            Console.WriteLine($"The house hits and draws a {newCard}.");
          }
          // - if House `<Hand>` > 21 print house hand and goto BUST:
          Console.WriteLine($"The house's hand scores: {house.Score()}");
          if (house.Score() > 21)
          {
            Console.WriteLine("The house busts. You win!");
          }
          else
          {
            if (house.Score() >= player.Score())
            {
              Console.WriteLine("The house wins!");
            }
            else
            {
              Console.WriteLine("You win!");
            }
          }
        }
        //   - Print "Would you like to play again?"
        Console.WriteLine("Would you like to play again? (y)es or (n)o...");
        var answer = Console.ReadLine();
        while (!answer.ToLower().StartsWith("y") && !answer.ToLower().StartsWith("n"))
        {
          Console.WriteLine("I didn't understand that answer.");
          answer = Console.ReadLine();          
        }
        if (answer.ToLower().StartsWith("n"))
        {
          Console.WriteLine("GoodBye!");
          break;
        }
      }
    }
  }
}
