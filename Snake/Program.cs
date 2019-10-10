using System;
using System.Collections.Generic;

namespace Snake
{
    class Program
    {
        static void Main()
        {
            Game game = new Game(80, 30);
            game.PlayGame();
        }
    }
}
