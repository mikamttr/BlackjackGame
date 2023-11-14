class Game
{
    private Deck deck;
    private Player player;
    private Dealer dealer;

    public Game()
    {
        deck = new Deck();
        player = new Player();
        dealer = new Dealer();
    }

    public void Play()
    {
        // Distribue 2 cartes au joueur et au croupier
        player.ReceiveCard(deck.DealCard());
        dealer.ReceiveCard(deck.DealCard());
        player.ReceiveCard(deck.DealCard());
        dealer.ReceiveCard(deck.DealCard());

        // Affiche la main de départ
        Console.WriteLine($"Votre main: {player.DisplayHand()}");
        Console.WriteLine($"Le croupier: {dealer.DisplayHand(showAll: false)}");

        // Tour du joueur
        while (player.GetHandValue() < 21)
        {
            Console.Write("Voulez-vous une carte ou arrêter ici (c/s): ");
            char choice = Console.ReadKey().KeyChar;
            Console.WriteLine();

            if (choice == 'c')
            {
                player.ReceiveCard(deck.DealCard());
                Console.WriteLine($"Votre main: {player.DisplayHand()}");
            }
            else if (choice == 's')
            {
                break;
            }
        }

        // Tour du croupier
        dealer.PlayHisTurn(deck);

        // Affiche la main finale
        Console.WriteLine("______________________________________");
        Console.WriteLine($"Votre main: {player.DisplayHand()}");
        Console.WriteLine($"Le croupier: {dealer.DisplayHand()}");

        // Determine le gagnant
        int playerValue = player.GetHandValue();
        int dealerValue = dealer.GetHandValue();

        if (playerValue > 21 || (dealerValue <= 21 && dealerValue >= playerValue))
        {
            Console.WriteLine("Le croupier l'emporte!");
        }
        else
        {
            Console.WriteLine("Félicitation !!! vous avez gagné!");
        }
    }
}
