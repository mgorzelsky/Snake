using System;
using System.Collections.Generic;

namespace Snake
{
    class SnakeClass
    {

        private int xPos;
        private int yPos;
        private List<(int, int)> body;
        private (int x, int y) headPos;
        private (int x, int y) tailPos;

        //static void Main(string[] args)
        //{
        public SnakeClass()
        {
            headPos = (5, 5); // Arbitrary head & tail initial position.
            tailPos = (3, 5);
            body = new List<(int, int)>(3) { (headPos), (headPos.x - 1, tailPos.y), (tailPos) };
        }

        public static void Eat()
        {

        }

        public static void LengthenSnake()
        {

        }

        public static void GetDirection()
        {

        }

        // Index 1 is the snake head
        public static void GetSnakePosition()
        {

        }

        public static void Move()
        {

        }

        //}
    }
}
