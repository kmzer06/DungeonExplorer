using System;
using System.Media;
using System.Collections.Generic;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Room currentRoom;

        public void Start()
        {
            // Initialize the game
            Console.Write("Enter your name: ");
            string playerName = Console.ReadLine();
            player = new Player(playerName, 100); // Player starts with 100 health
            currentRoom = new Room("A dark and mysterious cave. You see a faint light in the distance.", "Torch");

            Console.WriteLine("Welcome to Dungeon Explorer!");
            Console.WriteLine($"{player.PlayerName}, you find yourself in a dungeon...");
            Console.WriteLine(currentRoom.GetDescription());

            // Game loop
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("\nWhat would you like to do?");
                Console.WriteLine("1. View room description");
                Console.WriteLine("2. Check your status");
                Console.WriteLine("3. Pick up an item");
                Console.WriteLine("4. Exit the game");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine(currentRoom.GetDescription());
                        break;

                    case "2":
                        player.DisplayStatus();
                        break;

                    case "3":
                        Console.WriteLine("You look around for items...");
                        if (!string.IsNullOrEmpty(currentRoom.GetItem()))
                        {
                            player.PickUpItem(currentRoom.GetItem());
                            currentRoom.SetItem(null); // Remove the item from the room after picking it up
                        }
                        else
                        {
                            Console.WriteLine("There are no items in this room.");
                        }
                        break;

                    case "4":
                        Console.WriteLine("Thank you for playing Dungeon Explorer. Goodbye!");
                        isRunning = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }

    public class Player
    {
        public string PlayerName { get; private set; }
        public int Health { get; private set; }
        public Player(string playerName, int health)
        {
            PlayerName = playerName;
            Health = health;
        }

        public void DisplayStatus()
        {
            Console.WriteLine($"{PlayerName}'s Health: {Health}");
        }


        public void PickUpItem(string item)
        {
            inventory.Add(item);
            Console.WriteLine($"{PlayerName} picked up {item}.");
        }

            private List<string> inventory = new List<string>();
    }
}