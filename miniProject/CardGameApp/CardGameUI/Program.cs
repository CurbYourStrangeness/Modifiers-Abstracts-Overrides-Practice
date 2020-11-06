using NPOI.SS.Formula.Functions;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameUI
{
    class Program
    {
        static void Main(string[] args)
        {
            BSDeck handler = new BSDeck();
            handler.RequestCard();

            FoolsDeck foolish = new FoolsDeck();
            foolish.RequestCard();

            var hand = handler.DealCards();

            foreach (var card in hand)
            {
                Console.WriteLine($"{card.Suit.ToString()} {card.Num.ToString()}");
            }

            Console.ReadLine();
        }
    }

    public abstract class Deck
    {

        protected List<PlayingCardModel> fullDeck = new List<PlayingCardModel>();
        protected List<PlayingCardModel> drawPile = new List<PlayingCardModel>();
        protected List<PlayingCardModel> discardPile = new List<PlayingCardModel>();

        protected void CreateDeck()
        {
            fullDeck.Clear();

            for (int suit = 0; suit < 4; suit++)
            {
                for (int val = 0; val < 13; val++)
                {
                    fullDeck.Add(new PlayingCardModel { Suit = (CardSuit)suit, Num = (CardValue)val });
                }
            }
        }

        public virtual void ShuffleDeck()
        {
            Random r = new Random();

            var drawPile = fullDeck.OrderBy(x => r.Next()).ToList();

            //for (int i = fullDeck.Count() - 1; i > 0; i--)
            //{
            //    int n = r.Next(i + 1);
            //    var temp = fullDeck[i];
            //    fullDeck[i] = fullDeck[n];
            //    fullDeck[n] = temp;
            //}
        }
                

        public abstract List<PlayingCardModel> DealCards();

        public virtual PlayingCardModel RequestCard()
        {
            PlayingCardModel ret = drawPile.Take(1).First();
            drawPile.Remove(ret);

            return ret;
        }
    }

    public class BSDeck : Deck
    {

        public BSDeck()
        {
            CreateDeck();
            ShuffleDeck();
        }
        public override List<PlayingCardModel> DealCards()
        {
            List<PlayingCardModel> valSet = new List<PlayingCardModel>();
            for (int i = 0; i < 8; i++)
            {
                valSet.Add(RequestCard());
            }

            return valSet;
        }

        public List<PlayingCardModel> CardReqs(List<PlayingCardModel> discards)
        {
            List<PlayingCardModel> output = new List<PlayingCardModel>();

            foreach (var card in discards)
            {
                output.Add(RequestCard());
                discardPile.Add(card);
            }

            return output;
        }
    }

    public class FoolsDeck : Deck
    {
        public FoolsDeck(){
            CreateDeck();
            ShuffleDeck();
        }

        public override List<PlayingCardModel> DealCards()
        {  
            List<PlayingCardModel> valSet = new List<PlayingCardModel>();
            for (int i = 0; i < 51; i++)
            {
                valSet.Add(RequestCard());
            }

            return valSet;
        }

        public PlayingCardModel CardReq()
        {
            return RequestCard();
        }
    }
}
