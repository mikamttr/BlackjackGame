using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("Bienvenue sur Blackjack sur console");

        while (true)
        {
            Game blackjackGame = new Game();
            blackjackGame.Play();

            Console.Write("Voulez-vous rejouer? (o/n): ");
            char response = Console.ReadKey().KeyChar;
            if (response != 'o')
                break;

            Console.Clear();
        }
    }
}
