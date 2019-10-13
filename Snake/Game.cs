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
        private readonly Timer timer = new Timer(150);
        private readonly int width;
        private readonly int height;
        private bool gameRunning = true;
        private StateOfLocation[,] gameBoard;
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
        
        //Main game loop
        public void PlayGame()
        {
            snake = new SnakeClass();
            food = new Food(60, 15);

            Console.Clear();
            Console.CursorVisible = false;
            Console.SetWindowSize(1, 1);
            Console.SetBufferSize(width, height);
            Console.SetWindowSize(width, height);

            /* //Testing of snake coordinates
            gameBoard = new StateOfLocation[width, height];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    gameBoard[x, y] = StateOfLocation.Snake;
                }
            }
            Console.WriteLine(gameBoard.GetLength(0));
            Console.WriteLine(gameBoard.GetLength(1));
            Console.ReadKey();

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Console.Write(gameBoard[x, y]);
                }
            }
            Console.ReadKey();
            */

            timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            timer.Enabled = true;

            //Waiting for player input while the rest of the state runs on a timer
            while (gameRunning)
            {
                ConsoleKey snakeDirection = Console.ReadKey(true).Key;

                if (ConvertToString(snakeDirection) == ReverseDirection(snake.GetDirection()))
                {
                }
                else if (snakeDirection == ConsoleKey.UpArrow)
                {
                    snake.ChangeDirection("Up");
                }
                else if (snakeDirection == ConsoleKey.LeftArrow)
                {
                    snake.ChangeDirection("Left");
                }
                else if (snakeDirection == ConsoleKey.DownArrow)
                {
                    snake.ChangeDirection("Down");
                }
                else if (snakeDirection == ConsoleKey.RightArrow)
                {
                    snake.ChangeDirection("Right");
                }
                else;
                    // Nothing

                //switch (snakeDirection)
                //{
                //    case ConsoleKey.UpArrow:
                //        snake.ChangeDirection("Up");
                //            break;
                //    case ConsoleKey.LeftArrow:
                //        snake.ChangeDirection("Left");
                //        break;
                //    case ConsoleKey.DownArrow:
                //        snake.ChangeDirection("Down");
                //        break;
                //    case ConsoleKey.RightArrow:
                //        snake.ChangeDirection("Right");
                //        break;
                //}
            }

            Console.SetCursorPosition(10, 5);
            Console.WriteLine("Game Over!");
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Step();
        }

        //Controls the pace of the game. Every time this is called the snake advances one space and collision checks are made
        private void Step()
        {
            gameBoard = new StateOfLocation[width, height];

            snake.MoveSnake();
            newSnakePosition = snake.GetSnakePosition();
            newFoodPosition = food.FoodPosition;
            gameBoard[newFoodPosition.X, newFoodPosition.Y] = StateOfLocation.Food;

            //foreach (Point segment in newSnakePosition)
            //{
            //    Console.WriteLine(segment);
            //}
            //Console.ReadKey();

            if (!CheckCollision())
            {
                foreach (Point segment in newSnakePosition)
                {
                    gameBoard[segment.X, segment.Y] = StateOfLocation.Snake;
                    //Console.WriteLine(gameBoard[segment.X, segment.Y]);       //Check to ensure the coords are being overwritten
                }
            }
            else
            {
                timer.Stop();
                gameRunning = false;
            }
            //Console.ReadKey();

            screen.DrawScreen(gameBoard, height, width);
        }

        private bool CheckCollision()
        {
            Point snakeHeadPosition = newSnakePosition[0];

            //Does the snake run out of the game area?
            //floor/ceiling
            if (snakeHeadPosition.Y < 0 || snakeHeadPosition.Y > height - 1)
                return true;
            //walls
            if (snakeHeadPosition.X < 0 || snakeHeadPosition.X > width - 1)
                return true;

            //Does the snake run into itself?
            if (gameBoard[snakeHeadPosition.X, snakeHeadPosition.Y] == StateOfLocation.Snake)
                return true;

            //Does the snake run into food?
            if (gameBoard[snakeHeadPosition.X, snakeHeadPosition.Y] == StateOfLocation.Food)
            {
                snake.Eat();
                food.ChangeFoodPosition(width, height);
                return false;
            }

            //Does the snake go into empty space?
            return false;
        }

        //Converts ConsoleKey to string for comparison to the snake direction
        private string ConvertToString(ConsoleKey variableAsString)
        {
            switch (variableAsString)
            {
                case ConsoleKey.UpArrow:
                    return "Up";
                case ConsoleKey.LeftArrow:
                    return "Left";
                case ConsoleKey.DownArrow:
                    return "Down";
                case ConsoleKey.RightArrow:
                    return "Right";
            }
            return "not a vaild choice";
        }

        //Takes in the snake direction and returns the reverse value for comparison.
        private string ReverseDirection(string snakeCurrentDirection)
        {
            switch (snakeCurrentDirection)
            {
                case "Up":
                    return "Down";
                case "Down":
                    return "Up";
                case "Left":
                    return "Right";
                case "Right":
                    return "Left";
            }
            return "not a valid choice";
        }
    }
}
