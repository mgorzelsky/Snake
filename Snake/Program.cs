using System;

namespace Snake
{
    class Program
    {
        static void Main()
        {
            Game snakeGame = new Game(80, 30);
            snakeGame.PlayGame();
        }
    }
}
