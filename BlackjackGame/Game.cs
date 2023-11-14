// Game.cs
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
        Console.WriteLine($"Argent actuel : {player.Money}");

        // Demande au joueur de faire un pari
        Console.Write("Faites votre pari : ");
        int betAmount = int.Parse(Console.ReadLine());

        // Vérifiez si le pari est valide
        if (betAmount <= player.Money && betAmount > 0)
        {
            // Soustrayez le montant du pari de l'argent du joueur
            player.Money -= betAmount;

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

            // Détermine le gagnant
            int playerValue = player.GetHandValue();
            int dealerValue = dealer.GetHandValue();

            if (playerValue > 21 || (dealerValue <= 21 && dealerValue >= playerValue))
            {
                Console.WriteLine("Le croupier l'emporte!");
            }
            else
            {
                Console.WriteLine("Félicitations !!! Vous avez gagné!");
            }

            // Restituez l'argent au joueur en fonction du résultat du jeu
            player.Money += CalculateWinnings(betAmount, playerValue, dealerValue);
        }
        else
        {
            Console.WriteLine("Pari non valide. Le montant du pari doit être positif et inférieur ou égal à votre argent actuel.");
        }
    }

    private int CalculateWinnings(int betAmount, int playerValue, int dealerValue)
    {
        if (playerValue > 21 || (dealerValue <= 21 && dealerValue >= playerValue))
        {
            Console.WriteLine($"Vous avez perdu {betAmount}.");
            return 0;
        }
        else
        {
            int winnings = 2 * betAmount; // Pari gagnant, gain double
            Console.WriteLine($"Vous avez gagné {winnings} !");
            return winnings;
        }
    }
}
