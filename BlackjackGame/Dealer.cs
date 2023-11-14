class Dealer : Player
{
    public void PerformTurn(Deck deck)
    {
        while (GetHandValue() < 17)
        {
            ReceiveCard(deck.DealCard());
        }
    }
}