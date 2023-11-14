class Deck
{
    private List<Card> cards;

    public Deck()
    {
        cards = GetShuffledDeck();
    }

    private List<Card> GetShuffledDeck()
    {
        List<Card> deck = new List<Card>();

        string[] symbols = { "♥", "♠", "♦", "♣" };
        string[] values = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Valet", "Dame", "Roi", "As" };

        foreach (var symbol in symbols)
        {
            foreach (var value in values)
            {
                deck.Add(new Card(value, symbol));
            }
        }

        Random random = new Random();
        int n = deck.Count;
        while (n > 1)
        {
            n--;
            int k = random.Next(n + 1);
            Card card = deck[k];
            deck[k] = deck[n];
            deck[n] = card;
        }

        return deck;
    }

    public Card DealCard()
    {
        Card card = cards[0];
        cards.RemoveAt(0);
        return card;
    }
}