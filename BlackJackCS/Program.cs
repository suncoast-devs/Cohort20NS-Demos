using System;
using System.Collections.Generic;

namespace BlackJackCS
{
  class Card
  {
    // STATE or DATA
    public string suit; // <- a property.
    public string face;

    // BEHAVIOR...

    // The constructor:
    public Card(string face, string suit) {
      this.face = face;
      this.suit = suit;
    }

    override public string ToString() {
      return $"{this.face} of {this.suit}";
    }
  }
  
  class Deck
  {
    public List<Card> cards;

    public Deck()
    {
      this.cards = new List<Card>();
      var suits = new List<string> { "Clubs", "Diamonds", "Hearts", "Spades" };
      var faces = new List<string> { "Ace", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Jack", "Queen", "King" };
      foreach (var suit in suits)
      {
        foreach (var face in faces)
        {
          this.cards.Add(new Card(face, suit));
        }                  
      }
    }

    public void Shuffle()
    {
      var numberOfCards = this.cards.Count;
      var randomNumberGenerator = new Random();

      for (var rightIndex = numberOfCards -1; rightIndex >= 1; rightIndex--)
      {
        var leftIndex = randomNumberGenerator.Next(rightIndex);
        var leftCard = this.cards[leftIndex];
        var rightCard = this.cards[rightIndex];
        this.cards[rightIndex] = leftCard;
        this.cards[leftIndex] = rightCard;      
      }
      
    }
  }
  
  class Program
  {
    static void Main(string[] args)
    {
      var deck = new Deck();
      deck.Shuffle();

      // Console.WriteLine(String.Join("\n", deck.cards));
      Console.WriteLine(deck.cards[0]); // <-  Empty.
      Console.WriteLine(deck.cards[1]);
    }
  }
}

// class Book {
//   string title;
//   string author;
//   public Book (string aTitle, string anAuthor)
//   {
//     this.title = aTitle;
//     this.author = anAuthor;
//   }
//   public void Read () {
//     this.DoStuff()
//       // Do fancy text-to-speech ooooh.
//   }
// }
// book = new Book()
// book.Read()
// Read (book) {
//   book.DoStuff()
//     // Do fancy text-to-speech ooooh.
// }
// Read(book)