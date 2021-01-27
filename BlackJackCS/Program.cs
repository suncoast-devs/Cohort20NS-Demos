using System;
using System.Collections.Generic;

namespace BlackJackCS
{
  class Card
  {
    // STATE or DATA
    public string Suit; // <- a property.
    public string Face;

    // BEHAVIOR...

    // The constructor:
    public Card(string face, string suit) {
      this.Face = face;
      this.Suit = suit;
    }

    override public string ToString() {
      return $"{this.Face} of {this.Suit}";
    }

    public int Value()
    {
      // Return 1 for an Ace
      // Return 2 for Two, Three, etc.
      // Return 10 for Jack, Queen, etc.
      return 0;
    }
  }
  
  class Deck
  {
    public List<Card> Cards;

    public Deck()
    {
      this.Cards = new List<Card>();
      var suits = new List<string> { "Clubs", "Diamonds", "Hearts", "Spades" };
      var faces = new List<string> { "Ace", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Jack", "Queen", "King" };
      foreach (var suit in suits)
      {
        foreach (var face in faces)
        {
          this.Cards.Add(new Card(face, suit));
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
      // ; <-- the top card.
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

      // for each card, add it's card.Value() to total;

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
        Console.WriteLine($"{card}");
      }
    }
  }

  class Program
  {
    static void Main(string[] args)
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
      Console.WriteLine("Your hand:");
      player.Print();

      // Ask Player to "hit" or "stay"
      Console.WriteLine("Would you like to (h)it or (s)tay?");
      var response = Console.ReadLine();
      if (response.ToLower().StartsWith("h"))
      {
        Console.WriteLine("You HIT");
        player.Add(deck.Deal());
        Console.WriteLine("Your hand:");
        player.Print();
        // If `<Hand>` score > 21 Player "busts"
      }
      else
      {
        Console.WriteLine("You Stayed");
      }
    }
  }
}
