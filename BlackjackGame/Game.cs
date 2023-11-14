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
        // Distribute 2 cards to the player and the dealer
        player.ReceiveCard(deck.DealCard());
        dealer.ReceiveCard(deck.DealCard());
        player.ReceiveCard(deck.DealCard());
        dealer.ReceiveCard(deck.DealCard());

        // Display initial hands
        Console.WriteLine($"Votre main: {player.DisplayHand()}");
        Console.WriteLine($"Le croupier: {dealer.DisplayHand(showAll: false)}");

        // Player's turn
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

        // Dealer's turn
        dealer.PerformTurn(deck);

        // Display final hands
        Console.WriteLine("______________________________________");
        Console.WriteLine($"Votre main: {player.DisplayHand()}");
        Console.WriteLine($"Le croupier: {dealer.DisplayHand()}");

        // Determine the winner
        int playerValue = player.GetHandValue();
        int dealerValue = dealer.GetHandValue();

        if (playerValue > 21 || (dealerValue <= 21 && dealerValue >= playerValue))
        {
            Console.WriteLine("La maison l'emporte!");
        }
        else
        {
            Console.WriteLine("Vous avez gagné!");
        }
    }
}
