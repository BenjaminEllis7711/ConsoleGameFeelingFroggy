using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeelingFroggy
{
    public class Frog
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        private string Froggy;
        private ConsoleColor FrogColor;
        public Frog(int initialX, int initialY, int width)
        {
            X = initialX;
            Y = initialY;
            Froggy = "\u03a0";
            FrogColor = ConsoleColor.Green;
            Width = width;
        }
        public void Draw()
        {
            Console.ForegroundColor = FrogColor;
            Console.SetCursorPosition(X, Y);
            Console.Write(Froggy);
            Console.ResetColor();

        }

    }
    public class Enemy
    {
        private int _speed;
        public int PosX { get; set; }
        public int PosY { get; set; }
        public string Car { get; set; }
        public int Speed { get; set; } // 1 (slowest to 10 (fastest)


        public Enemy() { }
        public Enemy(int x, int y, int z, string car)
        {
            PosX = x;
            PosY = y;
            Speed = z;
            Car = car;
        }
        public void MoveRight(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(" ");
            x++;
            Console.SetCursorPosition(x, y);
            Console.Write(">");

        }
        public void MoveLeft(int x, int y)
        {


            Console.SetCursorPosition(x, y);
            Console.Write(" ");
            x--;
            Console.SetCursorPosition(x, y);
            Console.Write("<");

        }

        public void Stay(int x, int y, string car)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(car);
        }

    }

}
