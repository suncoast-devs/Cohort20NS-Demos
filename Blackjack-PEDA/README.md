# Blackjack

[PEDA(C)](https://medium.com/launch-school/solving-coding-problems-with-pedac-29141331f93f) excercise; but with no C!

## P is for Problem

The game should be played with a standard deck of playing cards (52).

The house should be dealt two cards, hidden from the player until the house reveals its hand.

The player should be dealt two cards, visible to the player.

The player should have a chance to hit (i.e. be dealt another card) until they decide to stop or they bust (i.e. their total is over 21). At which point they lose regardless of the dealer's hand.

When the player stands, the house reveals its hand and hits (i.e. draw cards) until they have 17 or more.

If dealer goes over 21 the dealer loses.

The player should have two choices: "Hit" and "Stand."

Consider Aces to be worth 11, never 1.

The app should display the winner. For this mode, the winner is who is closer to a blackjack (21) without going over.

Ties go to the DEALER

There should be an option to play again. This should start a new game with a new full deck of 52 shuffled cards and new empty hands for the dealer and the player.


## E is for Examples

Example 1:

- Deck is shuffled 
- House is dealt 2 cards
- Player is dealt 2 cards: Jack of Clubs and 9 of Spades
- Player is given option to "hit" or "stay"
- Player chooses "stay"
- House reveals hand: 4 of Diamonds and 6 of Spades
- House "hits" and gets 4 of Hearts
- House "hits" and gets 9 of Clubs
- House "busts" and Player wins!
- Player is offered "Take your chips and go home" or "Play again"
- Player chooses to "Play again"
- Cards are removed from both hands and returned to deck
- Deck is shuffled...

Example 2:

- Deck is shuffled 
- House is dealt 2 cards
- Player is dealt 2 cards: Five of Spades and Seven of Clubs
- Player is given option to "hit" or "stay"
- Player chooses "hit"
- Player is dealt a Queen of Hearts
- Player "busts" and the house wins!
- Player is offered "Take your chips and go home" or "Play again"
- Player chooses to "Take your chips and go home"
- Program exits.

Example 3:

- Deck is shuffled 
- House is dealt 2 cards
- Player is dealt 2 cards: Jack of Clubs and 9 of Spades
- Player is given option to "hit" or "stay"
- Player chooses "stay"
- House reveals hand: Jack of Diamonds and 9 of Clubs
- House wins the tie!
- Player chooses to "Take your chips and go home"
- Program exits.

## D is for Data Structure

Nouns: Player, House, Deck, Hand, Card, Choice (e.g. "Hit", "Play again"), Message (e.g. "Dealer wins!"), Game

First pass, on identifying attributes of these nouns:

Player
  - Choice(s)
  - Hand

House
  - Hand

Hand
  - Cards
  - Total (or, "total" in the problem statement, sum of the Card values)

Deck
  - Cards

Card
  - Suit (string)
  - Face (string)
  - Value (int)

Choice (string)

Message (string)

Game
  - Player
  - House
  - Deck
  - State
    - Think in terms of attributes of the state:
      - PlayerScore
      - HouseScore
      - Winner
    - or, in phases to move through: { Shuffle, Deal, PlayerTurn, HouseTurn, EndGame, ... }

**Some Observations:**

Players, i.e. The Guest (you) and the House (or Dealer); they all have Hands. Essentially the same concept.

A Hand and a Deck are both a list of Cards. Could be the same type, just given different rules.

```
Stack
|    \
Deck  Hand
 |     |- Total
 |- Deal()      
```

**Let's get literal:**

Card:
  suit: `string`
  face: `string`
  value: `int`

Deck:
  - cards: `List<Card>`

Player, House:
  - hand: `List<Card>`
  - score: sum of hand values

Game:
  - deck: `Deck`
  - playerHand: `List<Card>`
  - houseHand: `List<Card>`
  - state:
      playerScore: `int`
      houseScore: `int`

## A is for Algorithm

`BEGIN`:
- Establish `<Deck>`
- Shuffle `<Deck>`
- Remove 2 cards and deal to House
- Remove 2 cards and deal to Player
- Print Player cards
`PLAYER_TURN`:
- Ask Player to "hit" or "stay"
  - If "hit", Remove 1 card from deck and add to Player Hand
  - If `<Hand>` score > 21 Player "busts"
    - goto: `BUST` else goto: `PLAYER_TURN`
  - If "stay" goto: `HOUSE_TURN`
`HOUSE_TURN`:
- If House `<Hand>` < 17
  - House "hits"
    - Remove 1 card from deck and add to House Hand
        - if House `<Hand>` < 17 goto: `HOUSE_TURN`:
        - if House `<Hand>` > 21 print house hand and goto: `BUST`:
        - else:
          - print house hand and goto: `GAME_END`
`BUST`:
  - Print current player Busts!
`GAME_END`:
  - if player score > dealer score: player wins!
    - else: dealer wins!
`REPLAY`:
  - Print "Would you like to play again?"
  - if yes/y: 
    - Goto: `BEGIN`
  - if no/n:
    - End Program

## Peek at C:

Deck: Establish, Shuffle, Remove

```pseudo-c#
class Deck           // <- a class
{
   List<Card> cards; // <- a property
   void Shuffle();   // <- a method
}
```

```
  var deck = new Deck()    // <- instance
  deck.Shuffle() 

   var deck_b = new Deck() // <- instance
  deck_b.Shuffle()
```

Hand: Add, checking score, print
Game: setup, player turn, house, turn, bust, game over, replay