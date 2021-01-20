using System;
using System.Collections.Generic;

namespace AllCardsOnDeckCS
{
  class Program
  {
    static void Main(string[] args)
    {
      List<string> deck = new List<string>();
      // string[] suits = { "Clubs", "Diamonds", "Hearts", "Spades" };
      List<string> suits = new List<string> { "Clubs", "Diamonds", "Hearts", "Spades" };
      // int i = 0;
      // while (i < n) {
      //   ...
      //   i++;
      // }
      // 
      // IS THE SAME AS
      // 
      // for (int i = 0; i < n; i++) {
      //      ^- Initializer
      //                 ^- Condition
      //                        ^- After-thought (or post-condition) some people mistakingly call it incremener)
      // }


      // suits.Length => 4
      // i => 0
      // print "The suit is Clubs" => suits[0]
      // i => 1
      // print "The suit is Diamonds" => suits[1]
      // ...
      // i => 3
      // print "The suit is Spades" => suits[3]
      // i => 4

      //  for each of suit in suits
      for (int suitIndex = 0; suitIndex < suits.Count; suitIndex++) {
        string suit = suits[suitIndex];
        // loop 13 times for said suit
        for(int faceIndex = 0; faceIndex < 13; faceIndex++) {
          string card;
          switch(faceIndex) {
            case 0:
              card = "Ace";
              break;
            case 10:
              card = "Jack";
              break;
            case 11:
              card = "Queen";
              break;
            case 12:
              card = "King";
              break;
            default:
              card = (faceIndex + 1).ToString();
              break;
          }
          // n is some number between 0 and 51
          // suitIndex = 0..3
          // faceIndex = 0..13
          // int n = faceIndex + (suitIndex * 13);

          // suitIndex faceIndex n
          // 0         0         0
          // 0         1         1
          // 0         2         2
          // ...
          // 0         11        11
          // 0         12        12
          // 1         0         13
          // 1         1         14
          // 1         2         15
          // 1         3         16
          // ...
          // 2         0         26
          // 2         1         27
          // ...
          // 3         12        51
          // deck[n] = $"{card} of {suit}";

          deck.Add($"{card} of {suit}");
        }
      }
      // Console.WriteLine(String.Join('\n', deck));
    }
  }
}
