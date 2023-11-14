class Player
{
    protected List<Card> hand;

    public Player()
    {
        hand = new List<Card>();
    }

    public void ReceiveCard(Card card)
    {
        hand.Add(card);
    }

    public int GetHandValue()
    {
        int value = 0;
        int numAces = 0;

        foreach (var card in hand)
        {
            if (card.Value == "As")
            {
                value += 11;
                numAces++;
            }
            else if (card.Value == "Valet" || card.Value == "Dame" || card.Value == "Roi")
            {
                value += 10;
            }
            else
            {
                value += int.Parse(card.Value);
            }
        }

        while (value > 21 && numAces > 0)
        {
            value -= 10;
            numAces--;
        }

        return value;
    }

    public string DisplayHand(bool showAll = true)
    {
        string handString = "";

        foreach (var card in hand)
        {
            if (showAll)
                handString += $"{card.Value} {card.Symbol}, ";
            else
                handString += "Carte cachée, ";
        }

        return handString.Substring(0, handString.Length - 2);
    }
}