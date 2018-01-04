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
           
            {
                return playing = false;
            }
           
        }

        public void End()
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



        public void Help()
        {
            Console.WriteLine(@"Enter any of the following commands to proceed:
             Look,
             Take (enter name of object),
             Inventory,
             N, S, E, W,
             Reset,
             Quit");
        }
        public void Look(Room room)
        {
            Console.WriteLine($"{room.Name}{room.Description}");
            for (int i = 0; i < room.Items.Count; i++)
            {
                Console.WriteLine($"Takeable items in room: {room.Items[i].Name} Description: {room.Items[i].Description}");
            }
        }
        public void TakeItem(string itemName)
        {
            Item item = CurrentRoom.Items.Find(Item => Item.Name.ToLower() == itemName);
            if (item != null)
            {
                CurrentRoom.Items.Remove(item);
                CurrentPlayer.Inventory.Add(item);
                CurrentPlayer.ShowInventory(CurrentPlayer);
            }
        }
        public void UseItem(string itemName)
        {
            Item item = CurrentPlayer.Inventory.Find(Item => Item.Name.ToLower() == itemName);
            if (itemName != null)
            {
                System.Console.WriteLine("As the needle tears the flesh you feel a sharp piercing pain that begins to spread throughout your whole body. the room begins to spin and then everything goes dark.");

                CurrentRoom = Rooms[6];

            }
        }

        public void BuildRooms()
        {
            Room roomOne = new Room("Room 1 ", "Your journey starts here,  there is a door to the west and broken bottles strewn about");
            Room roomTwo = new Room("Room 2 ", "There was some type of party in this room exits are to the east and west");
            Room roomThree = new Room("Room 3 ", "Two dead party goers in this room and several empty prescription bottles, there are doors to the east and west");
            Room roomFour = new Room("Room 4 ", "This room is supprisingly clean and sterile, there are doors to the east and west");
            Room roomFive = new Room("Room 5 ", "Someone has scrawled the word poison into the east wall in BLOOD, there is a door to the East, North, and South choose wisely");
            Room roomSix = new Room("LOSER!!!, ", "This is a bottomless pit, you will die after starving in eternal free fall!!");
            Room roomSeven = new Room("YOU WIN!!, ", "You wake in your bed up and realize it was all a dream. Don't do drugs kids!!!");
            Room roomEight = new Room("LOSER!!!, ", "You just walked in on two lucha libre midget wrestlers who promptly beat you to death");

            AddRooms();
            BuildExits();
            MakeItem();

            void AddRooms()
            {
                Rooms.Add(roomOne);
                Rooms.Add(roomTwo);
                Rooms.Add(roomThree);
                Rooms.Add(roomFour);
                Rooms.Add(roomFive);
                Rooms.Add(roomSix);
                Rooms.Add(roomSeven);
                Rooms.Add(roomEight);
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
                roomFive.AddDoor("s", roomEight);
            }
            void MakeItem()
            {
                Item syringe = new Item("Syringe", "An ominous looking greenish fluid glows within this dull, bent and obviously used Syringe");
                roomFive.Items.Add(syringe);
                // Item bottle = new Item("Bottle", "Its empty and likely useless");
                // roomFour.Items.Add(bottle);
            }
            CurrentRoom = roomOne;

        }



    }
}


