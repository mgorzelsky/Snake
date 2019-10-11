using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> direc = new List<string>() { "Down", "Right", "Up", "Left" };
            SnakeClass tBody = new SnakeClass();

            foreach (string word in direc)
            {
                tBody.ChangeDirection(word);

                for (int k = 0; k < 3; k++)
                {
                    Console.WriteLine(tBody.GetSnakePosition()[k]);

                }
                for (int n = 0; n < 3; n++)
                {

                    tBody.MoveSnake();
                    for (int k = 0; k < 3; k++)
                    {
                        Console.WriteLine(tBody.GetSnakePosition()[k]);

                    }
                }
            }


        }
    }
}
