using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("Bienvenu sur Blackjack sur console");

        while (true)
        {
            PlayGame();

            Console.Write("Voulez vous rejouer? (o/n): ");
            char response = Console.ReadKey().KeyChar;
            if (response != 'o')
                break;

            Console.Clear();
        }
    }

    static void PlayGame()
    {
        // Initialise le deck de carte et le mélange
        List<Card> deck = GetShuffledDeck();

        // Initialise le joueur et le croupier
        List<Card> playerHand = new List<Card>();
        List<Card> dealerHand = new List<Card>();

        // Distribue 2 cartes au joueur et au croupier
        playerHand.Add(DealCard(deck));
        dealerHand.Add(DealCard(deck));
        playerHand.Add(DealCard(deck));
        dealerHand.Add(DealCard(deck));

        // Affiche la main de départ
        Console.WriteLine($"Votre main: {DisplayHand(playerHand)}");
        Console.WriteLine($"Le croupier: {DisplayHand(dealerHand, showAll: false)}");

        // Tour du joueur
        while (GetHandValue(playerHand) < 21)
        {
            Console.Write("Voulez vous une carte ou stopper ici (c/s): ");
            char choice = Console.ReadKey().KeyChar;
            Console.WriteLine();

            if (choice == 'c')
            {
                playerHand.Add(DealCard(deck));
                Console.WriteLine($"Votre main: {DisplayHand(playerHand)}");
            }
            else if (choice == 's')
            {
                break;
            }
        }

        // Tour du croupier
        while (GetHandValue(dealerHand) < 17)
        {
            dealerHand.Add(DealCard(deck));
        }

        // Affiche la main finale
        Console.WriteLine("______________________________________");
        Console.WriteLine($"Votre main: {DisplayHand(playerHand)}");
        Console.WriteLine($"Le croupier: {DisplayHand(dealerHand)}");

        // Determine le gagnat
        int playerValue = GetHandValue(playerHand);
        int dealerValue = GetHandValue(dealerHand);

        if (playerValue > 21 || (dealerValue <= 21 && dealerValue >= playerValue))
        {
            Console.WriteLine("La maison l'emporte!");
        }
        else
        {
            Console.WriteLine("Vous avez gagné!");
        }
    }

    static List<Card> GetShuffledDeck()
    {
        List<Card> deck = new List<Card>();

        // Crée un deck de cartes
        string[] symbols = { "♥", "♠", "♦", "♣" };
        string[] valeurs = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Valet", "Dame", "Roi", "As" };

        foreach (var symbol in symbols)
        {
            foreach (var valeur in valeurs)
            {
                deck.Add(new Card(valeur, symbol));
            }
        }

        // Mélange le deck de cartes
        Random random = new Random();
        int n = deck.Count;
        while (n > 1)
        {
            n--;
            int k = random.Next(n + 1);
            Card value = deck[k];
            deck[k] = deck[n];
            deck[n] = value;
        }

        return deck;
    }

    static Card DealCard(List<Card> deck)
    {
        Card card = deck[0];
        deck.RemoveAt(0);
        return card;
    }

    static int GetHandValue(List<Card> hand)
    {
        int value = 0;
        int numAces = 0;

        foreach (var card in hand)
        {
            if (card.Valeur == "As")
            {
                value += 11;
                numAces++;
            }
            else if (card.Valeur == "Valet" || card.Valeur == "Dame" || card.Valeur == "Roi")
            {
                value += 10;
            }
            else
            {
                value += int.Parse(card.Valeur);
            }
        }

        // Handle Aces
        while (value > 21 && numAces > 0)
        {
            value -= 10;
            numAces--;
        }

        return value;
    }

    static string DisplayHand(List<Card> hand, bool showAll = true)
    {
        string handString = "";

        foreach (var card in hand)
        {
            if (showAll)
                handString += $"{card.Valeur} {card.Symbol}, ";
            else
                handString += "Carte inconnue, ";
        }

        return handString.Substring(0, handString.Length - 2);
    }
}

class Card
{
    public string Valeur { get; }
    public string Symbol { get; }

    public Card(string valeur, string symbol)
    {
        Valeur = valeur;
        Symbol = symbol;
    }
}

