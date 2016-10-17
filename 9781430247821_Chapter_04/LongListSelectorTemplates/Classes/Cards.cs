using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media.Imaging;

namespace LongListSelectorTemplates.Classes
{
    public enum SuitType { Clubs, Spades, Hearts, Diamonds }
    public enum CardType
    {
        Two = 2, Three = 3, Four = 4, Five = 5, Six = 6,
        Seven = 7, Eight = 8, Nine = 9, Ten = 10,
        Jack = 11, Queen = 12, King = 13, Ace = 14
    }

    public class Suit
    {
        public SuitType SuitType { get; set; }

        public BitmapImage Image
        {
            get
            {
                const string pathFormat = "/Assets/Suits/tile_suit_{0}.png";
                string path = string.Format(pathFormat, this.ToString());
                return new BitmapImage(new System.Uri(path, System.UriKind.Relative));
            }
        }

        public override string ToString()
        {
            // Display as "Hearts", "Spades", etc.
            return this.SuitType.ToString("G");
        }
    }

    public class Card
    {
        public Suit Suit { get; internal set; }
        public CardType CardType { get; internal set; }
        public BitmapImage Image
        {
            get
            {
                const string pathFormat = "/Assets/Cards/{0:d}_{1}.png";
                string path = string.Format(pathFormat, CardType, Suit.ToString());
                return new BitmapImage(new System.Uri(path, System.UriKind.Relative));
            }
        }

        public override string ToString()
        {
            return CardType.ToString("G") + " of " + this.Suit.ToString();
        }
    }

    public class Deck
    {
        public IList<Group<Suit, Card>> GroupedCards
        {
            get;
            private set;
        }

        public int Count
        {
            get;
            private set; 
        }

        public Deck()
        {
            // get list of group objects
            var suits =
                from SuitType suitType in Enum.GetValues(typeof(SuitType))
                select new Suit() { SuitType = suitType };

            // get a flat list of detail objects that include the group data
            IEnumerable<Card> cards =
                from suit in suits
                from CardType cardType in Enum.GetValues(typeof(CardType))
                select new Card()
                {
                    CardType = cardType,
                    Suit = suit
                };

            this.Count = cards.Count(); 

            // group the detail
            this.GroupedCards =
                (from card in cards
                group card by card.Suit into grouped
                 select new Group<Suit, Card>(grouped.Key, grouped)).ToList();
        }
    }
}
