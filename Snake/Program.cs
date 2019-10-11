using System;
using System.Collections.Generic;

namespace Snake
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


                ConsoleKey playAgainChoice = Console.ReadKey().Key;
                if (playAgainChoice != ConsoleKey.Y)
                    playAgain = false;
            }
        }
    }
}
         
