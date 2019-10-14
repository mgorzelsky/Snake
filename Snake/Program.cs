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
                Game game = new Game(80, 30);
                game.PlayGame();


                ConsoleKey playAgainChoice = Console.ReadKey(true).Key;
                if (playAgainChoice != ConsoleKey.Y)
                    playAgain = false;
            }
        }
    }
}