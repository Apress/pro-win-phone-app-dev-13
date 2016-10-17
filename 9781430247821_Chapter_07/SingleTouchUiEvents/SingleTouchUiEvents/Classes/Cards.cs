using System;
using System.Collections.Generic;
using System.Linq;

namespace SingleTouchUiEvents.Classes
{
    public enum SuitType { Clubs, Spades, Hearts, Diamonds }
    public enum CardType
    {
        Two = 2, Three = 3, Four = 4, Five = 5, Six = 6,
        Seven = 7, Eight = 8, Nine = 9, Ten = 10,
        Jack = 11, Queen = 12, King = 13, Ace = 14
    }

    public class Card
    {
        public SuitType SuitType { get; internal set; }
        public CardType CardType { get; internal set; }
    }

    public class Deck
    {
        private Random _random = new Random();
        private List<Card> _cards;
        public Deck()
        {
            // build the array of cards
            _cards =
                (from SuitType suitType in Enum.GetValues(typeof(SuitType))
                 from CardType cardType in Enum.GetValues(typeof(CardType))
                 select new Card()
                 {
                     CardType = cardType,
                     SuitType = suitType
                 }).ToList();
        }

        // return a random card from the deck
        public Card Deal()
        {
            Card dealtCard = null;
            if (_cards.Count > 0)
            {
                dealtCard = _cards[_random.Next(0, _cards.Count - 1)];
                _cards.Remove(dealtCard);
            }
            return dealtCard;
        }

        public int Count { get { return _cards.Count; } }
    }
}