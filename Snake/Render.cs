using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeClass
{
    class Render
    {
        //  variables

        //  methods
        public void DrawScreen(StateOfLocation[,] gameBoard)
        {
            for (int i = 0; i < gameBoard.GetLength(0); i++)
            {
                for (int j = 0; j < gameBoard.GetLength(1); j++)
                {
                    Console.SetCursorPosition(j, i);        // this method requires you send the columns first (x values), then rows
                    switch (gameBoard[i, j])
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
        //  constructors

    }
}
