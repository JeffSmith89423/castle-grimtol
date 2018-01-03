using System;
using System.Collections.Generic;

namespace CastleGrimtol.Game
{
    public class Game : IGame
    {
        public Boolean Playing { get; set; }
        public Room CurrentRoom { get; set; }
        public Player CurrentPlayer { get; set; }
        public List<Room> Rooms { get; set; }
        public void Setup()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Castle Grimtol");
            CurrentPlayer = new Player();
            Rooms = new List<Room>();
            Help();
        }
        public string GetUserInput()
        {
            System.Console.WriteLine("What would you like to do?");
            string input = Console.ReadLine();
            return input;
        }
        public Boolean Quit(Boolean playing)
        {
            System.Console.WriteLine("Are you Sure?");
            string input = Console.ReadLine().ToLower();
            if (input == "y" || input == "yes")
            {
                return playing = false;
            }
            else
            {
                System.Console.WriteLine("OK");
                return playing = true;
            }
        }

        public void Lose()
        {
            Console.WriteLine("Would you like to quit? Y/N");
            string input = Console.ReadLine().ToLower();
            if (input == "y" || input == "yes")
            {
                Playing = false;
            }
            else
            {
                System.Console.WriteLine("OK");
                Reset();

            }

        }

        public void Reset()
        {
            Playing = true;
            Setup();
            BuildRooms();
        }

        public void UseItem(string itemName)
        {

        }

        public void Help()
        {
            Console.WriteLine(@"Enter any of the following commands to proceed:
             Look,
             Take,
             E, 
             W,
             Reset,
             Quit");
        }
        public void Look(Room room)
        {
            Console.WriteLine($"{room.Name}{room.Description}");

        }
        public void BuildRooms()
        {
            Room roomOne = new Room("Room 1 ", "You start out here, there is a door to the west");
            Room roomTwo = new Room("Room 2 ", "This is the second room, there are doors to the east and west");
            Room roomThree = new Room("Room 3 ", "This is the third room, there are doors to the east and west");
            Room roomFour = new Room("Room 4 ", "This is the fourth room, there are doors to the east and west");
            Room roomFive = new Room("Room 5 ", "This is the fifth room, there is a door to the east north and south choose wisely");
            Room roomSix = new Room("LOSER!!!, ", "This is a bottomless pit, you  die after starving in eternal free fall!!");
            Room roomSeven = new Room("YOU WIN!!, ", "This is the exit to the world's lamest maze!");


            AddRooms();
            BuildExits();


            void AddRooms()
            {
                Rooms.Add(roomOne);
                Rooms.Add(roomTwo);
                Rooms.Add(roomThree);
                Rooms.Add(roomFour);
                Rooms.Add(roomFive);
                Rooms.Add(roomSix);
                Rooms.Add(roomSeven);
            }
            void BuildExits()
            {
                roomOne.AddDoor("w", roomTwo);
                roomTwo.AddDoor("e", roomOne);
                roomTwo.AddDoor("w", roomThree);
                roomThree.AddDoor("e", roomTwo);
                roomThree.AddDoor("w", roomFour);
                roomFour.AddDoor("e", roomThree);
                roomFour.AddDoor("w", roomFive);
                roomFive.AddDoor("e", roomFour);
                roomFive.AddDoor("n", roomSix);
                roomFive.AddDoor("s", roomSeven);


            }
            CurrentRoom = roomOne;
        }

    }
}


