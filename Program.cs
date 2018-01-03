using System;
using System.Collections.Generic;
using CastleGrimtol.Game;


namespace CastleGrimtol
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Game.Game game = new Game.Game();

            game.Playing = true;

            game.Setup();
            game.BuildRooms();
            game.Look(game.CurrentRoom);


            while (game.Playing)
            {
                if (game.CurrentRoom.Name == "LOSER!!!, ")
                {
                    game.Lose();
                }
                if (game.CurrentRoom.Name == "YOU WIN!!, ")
                {
                  game.Lose();
                }
                string userChoice = game.GetUserInput().ToLower();
                string[] userAction = userChoice.Split(' ');
                Room nextRoom;
                game.CurrentRoom.Exits.TryGetValue(userAction[0], out nextRoom);

                if (userAction[0] == "l" || userAction[0] == "look")
                {
                    System.Console.WriteLine("\n");
                    game.Look(game.CurrentRoom);
                }
                else if (userAction[0] == "h" || userAction[0] == "help")
                {
                    game.Help();
                }

                else if (userAction[0] == "q" || userAction[0] == "quit")
                {
                    game.Playing = game.Quit(game.Playing);
                }
                else if (userAction[0] == "u" || userAction[0] == "use")
                {
                    game.UseItem(userAction[1]);
                    game.Look(game.CurrentRoom);
                }
                else if (userAction[0] == "r" || userAction[0] == "reset")
                {
                    game.Reset();

                }
                else if (nextRoom != null)
                {
                    game.CurrentRoom = nextRoom;
                    System.Console.WriteLine("\n");

                    game.Look(game.CurrentRoom);
                }
                else
                {

                    System.Console.WriteLine("Nope, you're dumb!!");

                }

            }
        }
    }
}
