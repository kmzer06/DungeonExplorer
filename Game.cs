using System;
using System.Media;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Room currentRoom;

        public Game(Player player, Room startingRoom)
        {
            this.player = player;
            this.currentRoom = startingRoom;
        }

        public void Start()
        {
            bool playing = true;
            Console.WriteLine("Welcome to Dungeon Explorer!");
            Console.WriteLine("Type 'help' for a list of commands.");

            while (playing)
            {
                Console.Write("> ");
                string input = Console.ReadLine().ToLower();

                switch (input)
                {
                    case "help":
                        Console.WriteLine("Available commands:");
                        Console.WriteLine("look - Look around the room");
                        Console.WriteLine("pickup - Pick up the item in the room");
                        Console.WriteLine("inventory - Check your inventory");
                        Console.WriteLine("quit - Quit the game");
                        break;

                    case "look":
                        Console.WriteLine(currentRoom.GetDescription());
                        Console.WriteLine($"Room item: {currentRoom.GetRoomItem()}");
                        break;

                    case "pickup":
                        string item = currentRoom.GetRoomItem();
                        if (item != "none")
                        {
                            player.PickUpItem(item);
                            currentRoom.RemoveItem();
                            Console.WriteLine($"You picked up: {item}");
                        }
                        else
                        {
                            Console.WriteLine("There is no item to pick up.");
                        }
                        break;

                    case "inventory":
                        Console.WriteLine(player.InventoryContents());
                        break;

                    case "quit":
                        playing = false;
                        Console.WriteLine("Thank you for playing Dungeon Explorer!");
                        break;

                    default:
                        Console.WriteLine("Unknown command. Type 'help' for a list of commands.");
                        break;
                }
            }
        }
    }
}