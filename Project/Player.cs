using System;
using System.Collections.Generic;

namespace CastleGrimtol.Game
{
    public class Player : IPlayer
    {
        public string UserName;
        public List<Item> Inventory { get; set; }
public Player()
{
    UserName = NameCharacter();
    Inventory = new List<Item>();
}
        public string NameCharacter()
        {
            Console.WriteLine("What is your name traveler?");
            string UserName = Console.ReadLine();
            Console.WriteLine("GoodLuck on your adventure, " + UserName);
            return UserName;
        }
    }

}