
namespace BlackJack
{
    public class Hand
    {
        public List<Card> cards;
        public Hand()
        {
            cards = new List<Card>();
        }

        public void AddCard(Card card)
        {
            cards.Add(card);
        }

        public int GetHandScore()
        {
            int value = 0;
            int numAces = 0;

            foreach (Card card in cards)
            {
                if (card.Rank == Rank.Ace)
                {
                    numAces++;
                }
                value += GetCardValue(card);
            }

            while (value > CommonUse.MAXHANDSCORE && numAces > 0)
            {
                value -= 10;
                numAces--;
            }

            return value;
        }

        private int GetCardValue(Card card)
        {
            switch (card.Rank)
            {
                case Rank.Two:
                case Rank.Three:
                case Rank.Four:
                case Rank.Five:
                case Rank.Six:
                case Rank.Seven:
                case Rank.Eight:
                case Rank.Nine:
                case Rank.Ten:
                    return (int)card.Rank;
                case Rank.Jack:
                case Rank.Queen:
                case Rank.King:
                    return 10;
                case Rank.Ace:
                    return 11;
                default:
                    throw new InvalidOperationException("Invalid card rank");
            }
        }
    }
}
