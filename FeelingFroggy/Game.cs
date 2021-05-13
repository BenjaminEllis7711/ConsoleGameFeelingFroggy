using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeelingFroggy
{
    public class Game
    {
        public int _lane1Counter = 0;
        private World MyWorld;
        private Frog CurrentFrog;
        public int WindowHeight = 30;
        public int WindowWidth = 60;


        public void Start()
        {
            Console.WindowHeight = WindowHeight;
            Console.WindowWidth = WindowWidth;
            Console.Title = "Feeling Froggy";
            Console.CursorVisible = false;
            Console.WriteLine("Game is starting. Presse any key to continue.");
            Console.ReadKey();
            MyWorld = new World(GetGrid());
            CurrentFrog = new Frog(8, 10, 1);

            GameLoop();

        }

        public void PlayerInput()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            ConsoleKey key = keyInfo.Key;
            World safe = new World(GetGrid());
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if (safe.IsSafe(CurrentFrog.X, CurrentFrog.Y - 1))
                    {
                        CurrentFrog.Y -= 1;
                        break;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (safe.IsSafe(CurrentFrog.X, CurrentFrog.Y + 1))
                    {
                        CurrentFrog.Y += 1;
                        break;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (safe.IsSafe(CurrentFrog.X - 1, CurrentFrog.Y))
                    {
                        CurrentFrog.X -= 1;
                        break;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (safe.IsSafe(CurrentFrog.X + 1, CurrentFrog.Y))
                    {
                        CurrentFrog.X += 1;
                        break;
                    }
                    break;
                default:
                    break;
            }
        }

        private void DrawFrame()
        {
            Console.Clear();
            MyWorld.Draw();
            CurrentFrog.Draw();
        }

        public void GameLoop()
        {
            Enemy CarLane1 = new Enemy(3, 9);
            Enemy CarLane2 = new Enemy(2, 8);
            Enemy CarLane3 = new Enemy(5, 7);
            Enemy CarLane4 = new Enemy(8, 4);
            Enemy CarLane5 = new Enemy(13, 3);
            Enemy CarLane6 = new Enemy(3, 2);


            while (true)
            {
                DrawFrame();

                CarLane1.MoveRight(CarLane1.PosX, CarLane1.PosY);
                CarLane1.PosX += 2;
                CollisionCheck(CarLane1.PosX, CarLane1.PosY);
                if (CarLane1.PosX > 15) { CarLane1.PosX = 0; }


                CarLane2.MoveRight(CarLane2.PosX, CarLane2.PosY);
                CarLane2.PosX += 2;
                CollisionCheck(CarLane2.PosX, CarLane2.PosY);
                if (CarLane2.PosX > 15) { CarLane2.PosX = 0; }


                CarLane3.MoveRight(CarLane3.PosX, CarLane3.PosY);
                CarLane3.PosX += 2;
                CollisionCheck(CarLane3.PosX, CarLane3.PosY);
                if (CarLane3.PosX > 15) { CarLane3.PosX = 0; }


                CarLane4.MoveLeft(CarLane4.PosX, CarLane4.PosY);
                CarLane4.PosX -= 2;
                CollisionCheck(CarLane4.PosX, CarLane4.PosY);
                if (CarLane4.PosX <= 2) { CarLane4.PosX = 15; }


                CarLane5.MoveLeft(CarLane5.PosX, CarLane5.PosY);
                CarLane5.PosX -= 2;
                CollisionCheck(CarLane5.PosX, CarLane5.PosY);
                if (CarLane5.PosX <= 2) { CarLane5.PosX = 15; }


                CarLane6.MoveLeft(CarLane6.PosX, CarLane6.PosY);
                CarLane6.PosX -=






                CollisionCheck(CarLane6.PosX, CarLane6.PosY);
                if (CarLane6.PosX <= 2) { CarLane6.PosX = 15; }


                while (Console.KeyAvailable) { PlayerInput(); }
                //Check if player hit To do
                System.Threading.Thread.Sleep(200);

            }
        }

        public string[,] GetGrid()
        {
            string[,] grid = {
                {"~" , "~" , "~" , "~" , "~" , "~" , "~" , "~" , "~" , "~" ,"~" , "~" , "~" , "~" , "~" , "|" }, //  15x11
                {"|" , "$" , "=" , "=" , "$" , "$" , "$" , "=" , "=" , "=" ,"$" , "$" , "$" , "=" , "=" , "|" }, // End
                {"|" , " " , " " , " " , " " , " " , " " , " " , " " , " " ," " , " " , " " , " " , " " , "|" }, // Danger
                {"|" , " " , " " , " " , " " , " " , " " , " " , " " , " " ," " , " " , " " , " " , " " , "|" }, // Danger
                {"|" , " " , " " , " " , " " , " " , " " , " " , " " , " " ," " , " " , " " , " " , " " , "|" }, // Danger
                {"|" , " " , " " , " " , " " , " " , " " , " " , " " , " " ," " , " " , " " , " " , " " , "|" }, // Safe
                {"|" , " " , " " , " " , " " , " " , " " , " " , " " , " " ," " , " " , " " , " " , " " , "|" }, // Safe
                {"|" , " " , " " , " " , " " , " " , " " , " " , " " , " " ," " , " " , " " , " " , " " , "|" }, // Danger
                {"|" , " " , " " , " " , " " , " " , " " , " " , " " , " " ," " , " " , " " , " " , " " , "|" }, // Danger
                {"|" , " " , " " , " " , " " , " " , " " , " " , " " , " " ," " , " " , " " , " " , " " , "|" }, // Danger
                {"|" , " " , " " , " " , " " , " " , " " , " " , " " , " " ," " , " " , " " , " " , " " , "|" }, // Start 
                {"=" , "=" , "=" , "=" , "=" , "=" , "=" , "=" , "=" , "=" ,"=" , "=" , "=" , "=" , "=" , "|" },

            };

            return grid;
        }
        public void CollisionCheck(int x, int y)
        {
            Game newgame = new Game();
            if (x == CurrentFrog.X && y == CurrentFrog.Y)
            {
                Console.Clear();
                Console.SetCursorPosition(0, 0);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n\n\n***************OH NO, a bird got you. Better luck next time.**********");
                Console.ResetColor();
                newgame.Start();
            }
        }



    }

}
