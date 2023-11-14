class Dealer : Player
{
    public void PlayHisTurn(Deck deck)
    {
        while (GetHandValue() < 17)
        {
            ReceiveCard(deck.DealCard());
        }
    }
}