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
        //private StateOfLocation[,] collisionCheck;        //old logic, not needed
        private SnakeClass snake;
        private Food food;
        private List<Point> newSnakePosition;
        private Point newFoodPosition;
        Render screen = new Render();

        //Constructor to pass in screen size, allows game to be re-sized with the change of a single variable
        public Game(int width, int height)
        {
            this.width = width;
            this.height = height;
        }
        
        //
        public void PlayGame()
        {
            gameBoard = new StateOfLocation[width, height];
            //collisionCheck = new StateOfLocation[width, height];      //changed logic, don't need anymore
            snake = new SnakeClass();
            food = new Food(60, 15);

            Console.Clear();
            Console.CursorVisible = false;
            Console.SetWindowSize(1, 1);
            Console.SetBufferSize(width, height);
            Console.SetWindowSize(width, height);

            timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            timer.Enabled = true;

            while (gameRunning)
            {
                ConsoleKey snakeDirection = Console.ReadKey(true).Key;
                switch (snakeDirection)
                {
                    case ConsoleKey.UpArrow:
                        snake.ChangeDirection("Up");
                        break;
                    case ConsoleKey.LeftArrow:
                        snake.ChangeDirection("Left");
                        break;
                    case ConsoleKey.DownArrow:
                        snake.ChangeDirection("Down");
                        break;
                    case ConsoleKey.RightArrow:
                        snake.ChangeDirection("Right");
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

            snake.MoveSnake();
            newSnakePosition = snake.GetSnakePosition();
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

            screen.DrawScreen(gameBoard, height, width);
        }

        private bool CheckCollision()
        {
            Point snakeHeadPosition = newSnakePosition[0];
            //StateOfLocation snakeHeadAsEnum = StateOfLocation.Snake;      //Old logic, not needed
            //Does the snake run into itself?
            if (gameBoard[snakeHeadPosition.X, snakeHeadPosition.Y] == StateOfLocation.Snake)
                return true;

            //Does the snake run into a wall?
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
            if (gameBoard[snakeHeadPosition.X, snakeHeadPosition.Y] == StateOfLocation.Food)
            {
                snake.Eat();
                food.ChangeFoodPosition(width, height);
                return true;
            }

            //Does the snake go into empty space?
            return true;
        }
    }
}
