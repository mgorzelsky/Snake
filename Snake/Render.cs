
using System;
using System.Text;

namespace Snake
{
    public class Render
    {
        public void DrawScreen(StateOfLocation[,] gameState, int height, int width)
        {
            StringBuilder screenAsString = new StringBuilder("", height * width);
            char currentCharacter = Convert.ToChar(32);
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    switch (gameState[x, y])
                    {
                        case (StateOfLocation.Empty):
                            currentCharacter = /*Convert.ToChar(32)*/'-';
                            break;
                        case (StateOfLocation.Food):
                            currentCharacter = '*';
                            break;
                        case (StateOfLocation.Snake):
                            currentCharacter = '#';
                            break;
                    }
                    screenAsString.Append(new char[] { currentCharacter });
                }
            }
            Console.SetCursorPosition(0, 0);
            Console.Write(screenAsString);
        }
    }
}


/*
using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    class Render
    {
        //  methods
        public void DrawScreen(StateOfLocation[,] gameBoard)
        {
            for (int y = 0; y < gameBoard.GetLength(1); y++)
            {
                for (int x = 0; x < gameBoard.GetLength(0); x++)
                {
                    Console.SetCursorPosition(x, y);        // this method requires you send the columns first (x values), then rows
                    switch (gameBoard[x, y])
                    {
                        case StateOfLocation.Empty:
                            Console.Write("-");
                            break;
                        case StateOfLocation.Snake:
                            Console.Write("S");
                            break;
                        case StateOfLocation.Food:
                            Console.Write("F");
                            break;
                        default:
                            break;
                    }

                }
                Console.WriteLine();
            }
        }
    }
}
*/