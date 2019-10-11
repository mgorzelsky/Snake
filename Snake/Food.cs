using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;       // for Point object

namespace Snake
{
    class Food
    {
        //  variables and properties
        private Point foodPosition;

        public Point FoodPosition 
        {
            get { return foodPosition; }
        }

        // methods
        private void SetFoodPosition(int x, int y)
        {
            foodPosition.X = x;
            foodPosition.Y = y;
        }

        // changes the position of the food on the screen randomly
        public void ChangeFoodPosition()
        {
            Random rand = new Random();
            int newX = rand.Next(1, 80);            // range 1 - 79
            int newY = rand.Next(1, 30);            // range 1 - 29
            SetFoodPosition(newX, newY);
        }

        // constructor
        public Food(int x, int y)
        {
            Point p1 = new Point(x, y);
            foodPosition = p1;
        }
    }
}
