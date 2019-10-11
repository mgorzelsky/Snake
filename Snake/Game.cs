using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace Snake
{
    public enum StateOfLocation { Empty, Food, Snake }
    class Game
    {
        private Timer timer = new Timer(500);
        private int width;
        private int height;
        private StateOfLocation[,] gameBoard;
        private StateOfLocation[,] collisionCheck;
        private Snake snake;
        private Food food;
        
        public Game(int width, int height)
        {
            this.width = width;
            this.height = height;
        }
        
        public void PlayGame()
        {
            gameBoard = new StateOfLocation[width, height];
            collisionCheck = new StateOfLocation[width, height];
            snake = new Snake();
            food = new Food(60, 15);

            Console.Clear();
            Console.CursorVisible = false;
            Console.SetWindowSize(1, 1);
            Console.SetBufferSize(width, height + 1);
            Console.SetWindowSize(width, height + 1);

            timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            timer.Enabled = true;

            while (true)
            {
                Console.ReadKey();
            }
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Step();
        }

        private void Step()
        {
            Console.WriteLine("Hello World!");

            Snake.Move();
            //update snake position in collisionCheck[,];
            
            CheckCollision();
            
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                   gameBoard[y, x]  = collisionCheck[y, x];
                }
            }

            Render.DrawScreen(gameBoard);
        }

        private void CheckCollision()
        {
            //Does the snake run into itself?
                //game over
            //Does the snake run into a wall?
                //game over
            //Does the snake run into food?
                //Food.Eat()
            //Does the snake go into empty space?
                //cool, no collision
        }
    }
}
