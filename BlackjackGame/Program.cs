using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Définit l'encodage de sortie de la console en UTF-8 pour prendre en charge les caractères spéciaux.
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("Bienvenue sur Blackjack C# sur console \n");

        bool continuePlaying = true;

        // Boucle principale du programme qui permet de jouer plusieurs parties
        while (continuePlaying)
        {
            Game game = new Game(); // Crée une instance de la classe Game
            game.Start();

            // Demande à l'utilisateur s'il souhaite rejouer
            Console.Write("Voulez-vous rejouer? (o/n): ");
            char response = Console.ReadKey().KeyChar;

            // Vérifie si la réponse de l'utilisateur n'est pas 'o' (oui) pour sortir de la boucle
            if (response != 'o')
                continuePlaying = false;

            Console.Clear(); // Efface le contenu de la console pour une nouvelle partie
        }
    }
}