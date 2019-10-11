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
                    if (y == 0)
                        currentCharacter = '-';
                    if (y == 39)
                        currentCharacter = '-';
                    if (y > 0 && y < height - 1)
                    {
                        switch (gameState[x, y])
                        {
                            case (StateOfLocation.Empty):
                                currentCharacter = Convert.ToChar(32);
                                break;
                            case (StateOfLocation.Food):
                                currentCharacter = '*';
                                break;
                            case (StateOfLocation.Snake):
                                currentCharacter = '#';
                                break;
                        }
                    }
                    screenAsString.Append(new char[] { currentCharacter });
                    //Console.Write(gameState[y, x]);
                }
            }
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(screenAsString);
        }
    }
}

//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Snake
//{
//    class Render
//    {
//        //  variables

//        //  methods
//        public void DrawScreen(StateOfLocation[,] gameBoard)
//        {
//            for (int i = 0; i < gameBoard.GetLength(0); i++)
//            {
//                for (int j = 0; j < gameBoard.GetLength(1); j++)
//                {
//                    Console.SetCursorPosition(j, i);        // this method requires you send the columns first (x values), then rows
//                    switch (gameBoard[i, j])
//                    {
//                        case StateOfLocation.Empty:
//                            Console.Write("-");
//                            break;
//                        case StateOfLocation.Snake:
//                            Console.Write("S");
//                            break;
//                        case StateOfLocation.Food:
//                            Console.Write("F");
//                            break;
//                        default:
//                            break;
//                    }

//                }
//                Console.WriteLine();
//            }
//        }
//        //  constructors

//    }
//}
