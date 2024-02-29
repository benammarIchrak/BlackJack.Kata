
namespace BlackJack
{
    public class Game
    {
        public Hand playerHand;
        public Hand dealerHand;
        public Deck deck = new Deck();
        public bool DealerWin = false;
        public bool PlayerWin = false;

        public Game(Hand dealer, Hand player)
        {
            playerHand = player;
            dealerHand = dealer;
            deck.Shuffle();
        }

        public void Play(PlayerDecision playerDecision)
        {

            if (playerHand.GetHandScore() < CommonUse.MAXHANDSCORE && playerDecision == PlayerDecision.HIT)
            {
                playerHand.AddCard(deck.DealCard());
            }

            while (dealerHand.GetHandScore() < CommonUse.MINDEALERSCORE)
            {
                dealerHand.AddCard(deck.DealCard());
            }

            DetermineWinner(playerHand, dealerHand);
        }
        public void DetermineWinner(Hand playerHand, Hand dealerHand)
        {
            int playerTotal = playerHand.GetHandScore();
            int dealerTotal = dealerHand.GetHandScore();
            //check Rules in README File: https://dev.azure.com/kouka/Formation/_git/black-jack?path=/README.md&_a=preview
            //Rule1: If a player's hand total exceeds 21

            if (playerTotal > CommonUse.MAXHANDSCORE)
            {
                DealerWin = true;
            }
            //If a player's hand total is closer to 21 than the dealer's hand total without exceeding 21
            //If the dealer busts, all remaining players win.

            else if (dealerTotal > CommonUse.MAXHANDSCORE || playerTotal > dealerTotal)
            {
                PlayerWin = true;
            }

            else if (playerTotal < dealerTotal)
            {
                DealerWin = true;
            }
        }
    }
}
