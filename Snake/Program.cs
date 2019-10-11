using System;
using System.Collections.Generic;

namespace SnakeClass
{
    class Program
    {
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