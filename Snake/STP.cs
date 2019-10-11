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

            for (int k = 0; k < tBody.GetSnakePosition().Count; k++)
            {
                Console.WriteLine(tBody.GetSnakePosition()[k] + " ");

            }
            for (int n = 0; n < 5; n++)
            {

                tBody.Eat();
                for (int k = 0; k < tBody.GetSnakePosition().Count; k++)
                {
                    Console.WriteLine(tBody.GetSnakePosition().Count);
                    Console.WriteLine(tBody.GetSnakePosition()[k]);

                }
            }



        }
    }
}
