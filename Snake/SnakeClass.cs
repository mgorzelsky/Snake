using System;
using System.Collections.Generic;
using System.Drawing;

namespace Snake
{
    enum direction { right = 1, up = 2, left = 3, down = 4 };

    class SnakeClass
    {

        private static List<Point> body;
        private static Point headPos;
        private static Point tailPos;
        private static int currentDirection = direction.right;
        private static bool elongate = false;

        public SnakeClass()
        {
            headPos.X = tailPos.X = 5; // Arbitrary head & tail initial position.
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

        // LengthenSnake calls Move(), which will add one new segment to snake on tail at end of Move, before returning elongate to false.
        public static void LengthenSnake()
        {
            elongate = true;
            Move();
        }

        // Returns string "right", "up", "left", or "down" indicating the direction of head travel
        public static string GetDirection()
        {
            return (Enum.GetName(currentDirection));
        }

        // ChangeDirection takes the string "right", "up", "left", or "down" indicating the new direction of the snake. The string input is related to an int
        // per the enum above. 
        public static void ChangeDirection(string vector)
        {
            if (vector == Enum.GetName(1)) currentDirection = direction.right;
            else if (vector == Enum.GetName(2)) { currentDirection = direction.up; }
            else if (vector == Enum.GetName(3)) { currentDirection = direction.left; }
            else if (vector == Enum.GetName(4)) { currentDirection = direction.down; }
            
        }

        // This method returns a List of Points containing snake body coordinates. **Index 0 is the snake head.**
        public static List<Point> GetSnakePosition()
        {
            return (body);
        }

        // Move(): Store current headPos, get current direction & change Point coordinate of headPos accordingly. The second unit of snake will then assume 
        // the previous Point coordinate of the headPos, the third unit of snake will then assume the previous position of the second unit, and so on, until
        // all parts of the snake have advanced. 
        public static void Move()
        {
            Point oldPosition1 = headPos;

            switch ((direction)currentDirection)
            {
                case ("right"):
                    {
                        headPos.X += 1;
                        break;
                    }
                case ("up"):
                    {
                        headPos.Y -= 1; // Up is in the -Y direction on the console axis.
                        break;
                    }
                case ("left"):
                    {
                        headPos.X -= 1;
                        break;
                    }
                case ("down"):
                    {
                        headPos.Y += 1; // Down is in the +Y direction on the console axis.
                        break;
                    }

            }

            for(int index = 1; index < body.Count; index++)
            {
                Point oldPosition2 = body[index];
                body[index] = oldPosition1;
                oldPosition1 = oldPosition2;
            }
            if(elongate)
            {
                Point newTail = new Point();
                newTail = oldPosition1;
                body.Add(newTail);
                elongate = false;
            }
        }
    }
}
