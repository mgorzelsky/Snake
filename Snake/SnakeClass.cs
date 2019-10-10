using System;
using System.Collections.Generic;
using System.Drawing;

namespace Snake
{
    class SnakeClass
    {

        //private int xPos;
        //private int yPos;
        private static List<Point> body;
        private static Point headPos;
        private static Point tailPos;

        //static void Main(string[] args)
        //{
        public SnakeClass()
        {
            headPos.X  = tailPos.X= 5; // Arbitrary head & tail initial position.
            tailPos.X = 3;
            tailPos.Y = 5;
            Point midPos = new Point();
            midPos.X = headPos.X - 1;
            midPos.Y = headPos.Y;
            body = new List<Point>() { headPos, midPos, tailPos };
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
        public static List<Point> GetSnakePosition()
        {
            return (body);
        }

        public static void Move()
        {

        }

        //}
    }
}
