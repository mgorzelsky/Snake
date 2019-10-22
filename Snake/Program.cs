using System;
using System.Collections.Generic;

namespace Snake
{
    class Program
    {
        //Provides a starting point for the game itself. Will be used later for menu options such as difficulty,
        //high scores, and restarting after loss.
        static void Main()
        {
            bool playAgain = true;
            while (playAgain)
            {
                Game game = new Game(40, 15);
                int score = game.PlayGame();

                Console.SetCursorPosition(10, 5);
                Console.WriteLine("Game Over!");
                Console.SetCursorPosition(10, 6);
                Console.WriteLine("Score: {0}", score);

                ConsoleKey playAgainChoice = Console.ReadKey(true).Key;
                if (playAgainChoice != ConsoleKey.Y)
                    playAgain = false;
            }
        }
    }
}