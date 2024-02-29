namespace BlackJack
{
    public class Deck
    {
        private List<Card> cards;

        public Deck()
        {
            cards = new List<Card>();
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    cards.Add(new Card(suit, rank));
                }
            }
        }

        public void Shuffle()
        {
            Random rng = new Random();
            for (int i = 0; i < cards.Count; i++)
            {
                int randomIndex = rng.Next(1, cards.Count);
                Card cardTemp = cards[i];
                cards[i] = cards[randomIndex];
                cards[randomIndex] = cardTemp;
            }
        }

        public Card DealCard()
        {
            // Performance => to be enhanced!
            if (cards.Count == 0)
            {
                throw new InvalidOperationException("Deck is empty");
            }
            Card card = cards[0];
            cards.RemoveAt(0);
            return card;
        }

    }
}
