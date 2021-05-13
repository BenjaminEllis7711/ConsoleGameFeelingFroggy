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
        public int WindowHeight = 40;
        public int WindowWidth = 70;


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
            Enemy CarLane1 = new Enemy(3, 9, 6, ">");
            Enemy CarLane2 = new Enemy(2, 8, 9, ">");
            Enemy CarLane3 = new Enemy(5, 7, 3, ">");
            Enemy CarLane4 = new Enemy(8, 4, 8, "<");
            Enemy CarLane5 = new Enemy(13, 3, 3, "<");
            Enemy CarLane6 = new Enemy(3, 2, 6, "<");


            while (true)
            {
                DrawFrame();

                Random speed = new Random();
                int speedCheck = speed.Next(0, 10);
                if (CarLane1.Speed > speedCheck)
                {
                    CarLane1.MoveRight(CarLane1.PosX, CarLane1.PosY); /// Talking the car's speed (1-10), and seeing if its bigger than a number from random 0-10
                    CarLane1.PosX += 1;             //  lower the speed the lower the times in will hit 
                    CollisionCheck(CarLane1.PosX, CarLane1.PosY);
                    if (CarLane1.PosX > 15) { CarLane1.PosX = 0; }
                }
                else CarLane1.Stay(CarLane1.PosX, CarLane1.PosY, CarLane1.Car);

                speedCheck = speed.Next(0, 10);
                if (CarLane2.Speed > speedCheck)
                {
                    CarLane2.MoveRight(CarLane2.PosX, CarLane2.PosY);
                    CarLane2.PosX += 1;
                    CollisionCheck(CarLane2.PosX, CarLane2.PosY);
                    if (CarLane2.PosX > 15) { CarLane2.PosX = 0; }
                }
                else CarLane2.Stay(CarLane2.PosX, CarLane2.PosY, CarLane2.Car); 

                speedCheck = speed.Next(0, 10);
                if (CarLane3.Speed > speedCheck)
                {
                    CarLane3.MoveRight(CarLane3.PosX, CarLane3.PosY);
                    CarLane3.PosX += 1;
                    CollisionCheck(CarLane3.PosX, CarLane3.PosY);
                    if (CarLane3.PosX > 15) { CarLane3.PosX = 0; }
                }
                else CarLane3.Stay(CarLane3.PosX, CarLane3.PosY, CarLane3.Car);

                speedCheck = speed.Next(0, 10);
                if (CarLane4.Speed > speedCheck)
                {
                    CarLane4.MoveLeft(CarLane4.PosX, CarLane4.PosY);
                    CarLane4.PosX -= 1;
                    CollisionCheck(CarLane4.PosX, CarLane4.PosY);
                    if (CarLane4.PosX <= 2) { CarLane4.PosX = 15; }
                }
                else CarLane4.Stay(CarLane4.PosX, CarLane4.PosY, CarLane4.Car);

                speedCheck = speed.Next(0, 10);
                if (CarLane5.Speed > speedCheck)
                {
                    CarLane5.MoveLeft(CarLane5.PosX, CarLane5.PosY);
                    CarLane5.PosX -= 1;
                    CollisionCheck(CarLane5.PosX, CarLane5.PosY);
                    if (CarLane5.PosX <= 2) { CarLane5.PosX = 15; }
                }
                else CarLane5.Stay(CarLane5.PosX, CarLane5.PosY, CarLane5.Car);

                speedCheck = speed.Next(0, 10);
                if (CarLane6.Speed > speedCheck)
                {
                    CarLane6.MoveLeft(CarLane6.PosX, CarLane6.PosY);
                    CarLane6.PosX -= 1;
                    CollisionCheck(CarLane6.PosX, CarLane6.PosY);
                    if (CarLane6.PosX <= 2) { CarLane6.PosX = 15; }
                }
                else CarLane6.Stay(CarLane6.PosX, CarLane6.PosY, CarLane6.Car);


                while (Console.KeyAvailable) { PlayerInput(); }
                //Check if player hit To do
                System.Threading.Thread.Sleep(60);

            }
        }

        public string[,] GetGrid()
        {
            string[,] grid = {
                {"~" , "~" , "~" , "~" , "~" , "~" , "~" , "~" , "~" , "~" ,"~" , "~" , "~" , "~" , "~" , "|" }, //  15x11
                {"|" , "=" , "$" , "=" , "$" , "=" , "$" , "=" , "$" , "=" ,"$" , "=" , "$" , "=" , "=" , "|" }, // End
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
