using System;
using System.Media;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Game
    {
        private Player player;
        private Room currentRoom;
        private Dictionary<string, Room> rooms = new Dictionary<string, Room>();

        public void Start()
        {
            // Initialize the game
            Console.Write("Enter your name: ");
            string playerName = Console.ReadLine();
            player = new Player(playerName, 100); // Player starts with 100 health
            currentRoom = new Room("A dark and mysterious cave. You see a faint light in the distance.", "Torch");

            Console.WriteLine("Game started!");
            Console.WriteLine($"{player.Name} enters the dungeon...");
            Play();
        }

        private void InitializeRooms()
        {
            rooms["Cave"] = new Room("A dark and mysterious cave", "Torch");
            rooms["Hallway"] = new Room("A narrow hallway with torches on the walls", "Sword");
            rooms["Chamber"] = new Room("A grand chamber with a glowing chest", "Health Potion");
        }

        private void Play()
        {
            bool isPlaying = true;
            while (isPlaying)
            {
                Console.WriteLine($"You are in: {currentRoom.GetDescription()}");
                if (!string.IsNullOrEmpty(currentRoom.GetItem()))
                {
                    Console.WriteLine($"You found a {currentRoom.GetItem()}!");
                    player.PickUpItem(currentRoom.GetItem());
                    currentRoom.SetItem(null);
                }

                Console.WriteLine("What would you like to do? (move, status, quit)");
                string choice = Console.ReadLine().ToLower();
                switch (choice)
                {
                    case "move":
                        ChangeRoom();
                        break;
                    case "status":
                        player.DisplayStatus();
                        break;
                    case "quit":
                        isPlaying = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }
        }

        private void ChangeRoom()
        {
            Console.WriteLine("Where would you like to go? (Cave, Hallway, Chamber)");
            string newRoom = Console.ReadLine();
            if (rooms.ContainsKey(newRoom))
            {
                currentRoom = rooms[newRoom];
                Console.WriteLine($"You moved to {currentRoom.GetDescription()}.");
            }
            else
            {
                Console.WriteLine("That room doesn't exist.");
            }
        }
    }
}
