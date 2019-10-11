using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using System.Drawing;

namespace Snake
{
    public enum StateOfLocation { Empty, Food, Snake }
    class Game
    {
        private readonly Timer timer = new Timer(500);
        private readonly int width;
        private readonly int height;
        private bool gameRunning = true;
        private StateOfLocation[,] gameBoard;
        private StateOfLocation[,] collisionCheck;
        private Snake snake;
        private Food food;
        private List<Point> newSnakePosition;
        private Point newFoodPosition;


        public Game(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public int GetWidth()
        {
            return width;
        }

        public int GetHeight()
        {
            return height;
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

            while (gameRunning)
            {
                ConsoleKey snakeDirection = Console.ReadKey(true).Key;
                switch (snakeDirection)
                {
                    case ConsoleKey.UpArrow:
                        Snake.ChangeDirection("Up");
                        break;
                    case ConsoleKey.LeftArrow:
                        Snake.ChangeDirection("Left");
                        break;
                    case ConsoleKey.DownArrow:
                        Snake.ChangeDirection("Down");
                        break;
                    case ConsoleKey.RightArrow:
                        Snake.ChangeDirection("Right");
                        break;
                }
            }

            Console.SetCursorPosition(10, 5);
            Console.WriteLine("Game Over!");
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Step();
        }

        private void Step()
        {
            //Console.WriteLine("Hello World!");

            Snake.Move();
            newSnakePosition = Snake.GetSnakePosition();
            newFoodPosition = food.FoodPosition;
            gameBoard[newFoodPosition.X, newFoodPosition.Y] = StateOfLocation.Food;

            if (!CheckCollision())
            {
                //int snakeLength = newSnakePosition.Count;
                foreach (Point segment in newSnakePosition)
                {
                    gameBoard[segment.Y, segment.X] = StateOfLocation.Snake;
                }

                //for (int y = 0; y < height; y++)
                //{
                //    for (int x = 0; x < width; x++)
                //    {
                //        gameBoard[y, x] = collisionCheck[y, x];
                //    }
                //}
            }
            else
            {
                timer.Stop();
                gameRunning = false;
            }


            Render screen = new Render();
            screen.DrawScreen(gameBoard);
        }

        private bool CheckCollision()
        {
            Point snakeHeadPosition = newSnakePosition[0];
            //StateOfLocation snakeHeadAsEnum = StateOfLocation.Snake;
            //Does the snake run into itself?
            //game over
            //return true;
            if (gameBoard[snakeHeadPosition.X, snakeHeadPosition.Y] == StateOfLocation.Snake)
                return true;

            //Does the snake run into a wall?
            //game over
            //return true;
            for (int x = 0; x < width; x++)
            {
                Point[,] wall = new Point[x, 0];
                if (wall.Equals(gameBoard[snakeHeadPosition.X, snakeHeadPosition.Y]))
                    return true;
            }
            for (int x = 0; x < width; x++)
            {
                Point[,] wall = new Point[x, height - 1];
                if (wall.Equals(gameBoard[snakeHeadPosition.X, snakeHeadPosition.Y]))
                    return true;
            }
            for (int y = 0; y < height; y++)
            {
                Point[,] wall = new Point[y, 0];
                if (wall.Equals(gameBoard[snakeHeadPosition.X, snakeHeadPosition.Y]))
                    return true;
            }
            for (int y = 0; y < height; y++)
            {
                Point[,] wall = new Point[y, width - 1];
                if (wall.Equals(gameBoard[snakeHeadPosition.X, snakeHeadPosition.Y]))
                    return true;
            }

            //Does the snake run into food?
            //Food.Eat()
            //return false;
            if (gameBoard[snakeHeadPosition.X, snakeHeadPosition.Y] == StateOfLocation.Food)
            {
                snake.Eat();
                food.ChangeFoodPosition(width, height);
                return true;
            }

            //Does the snake go into empty space?
            //cool, no collision
            //return false;
            return false;
        }
    }
}
