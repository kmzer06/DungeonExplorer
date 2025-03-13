using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Welcome message and player name input
            Console.WriteLine("Welcome to Dungeon Explorer!");
            Console.Write("Please enter your name: ");
            string playerName = Console.ReadLine();

            // Initialize the player with 100 health
            Player player = new Player(playerName, 100);

            // Initialize the starting room
            Room startingRoom = new Room(
                "You are in a dimly lit room. The walls are covered in moss, and there's a faint smell of dampness in the air.",
                "Rusty Key"
            );

            // Initialize the game with the player and starting room
            Game game = new Game(player, startingRoom);

            // Start the game
            game.Start();

            // End of program
            Console.WriteLine("Thank you for playing Dungeon Explorer!");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
