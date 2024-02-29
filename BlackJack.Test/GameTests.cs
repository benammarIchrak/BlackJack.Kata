using Blackjack;
using BlackJack;
using Xunit;
namespace BlackJack.Test
{
    public class GameTests
    {
        [Theory]
        //Testing Rule1: player score>21 ===> Loose
        // the player choose to Hit another card while his total hand score is less than 21,
        // he will loose the cuz it will exceed 21!
        [InlineData(Suit.Diamond, Rank.Jack,Suit.Spade, Rank.Queen,Suit.Club, Rank.Eight,Suit.Diamond, Rank.King, PlayerDecision.HIT,false,true)]

        //Testing Rule 2: dealer score> 21 or player is closer to 21 than the dealer 
        // the player will keep the cards dealed initially in the game with total == 20
        // player win with score 20> 18 dealerScore
        [InlineData(Suit.Diamond, Rank.Jack, Suit.Spade, Rank.Queen, Suit.Club, Rank.Eight,Suit.Diamond, Rank.King,PlayerDecision.STAND,true,false)]

        //testing Rule 3: dealer_score < player_score <= 21 => Player Win
        [InlineData(Suit.Spade, Rank.Jack, Suit.Heart, Rank.Nine, Suit.Club, Rank.Queen, Suit.Diamond, Rank.Eight, PlayerDecision.STAND, true, false)]

        //testing Rule 4: player_score < dealer_score <= 21 => Dealer Win
        [InlineData(Suit.Spade, Rank.Four, Suit.Heart, Rank.Queen, Suit.Club, Rank.Queen, Suit.Diamond, Rank.Nine, PlayerDecision.STAND, false, true)]

        public void BlackJackGameShouldCorrectlyFindOutTheWinner(
            Suit suitplayer1,
            Rank rankplayer1, Suit suitplayer2,
            Rank rankplayer2, Suit suitdealer1,
            Rank rankdealer1, Suit suitdealer2,
            Rank rankdealer2, PlayerDecision decision,
            bool expectedPlayerWin,
            bool expectedDealerWin)
        {
            //arrange
            var playerHand = new Hand();
            var dealerHand = new Hand();
            playerHand.AddCard(new Card(suitplayer1, rankplayer1));
            playerHand.AddCard(new Card(suitplayer2, rankplayer2));
            dealerHand.AddCard(new Card(suitdealer1, rankdealer1));
            dealerHand.AddCard(new Card(suitdealer2, rankdealer2));
            Game game = new Game(dealerHand, playerHand);

            //act
            game.Play(decision);

            //assert
            Assert.Equal(expectedPlayerWin,game.PlayerWin);
            Assert.Equal(expectedDealerWin, game.DealerWin);
        }
    }
}
