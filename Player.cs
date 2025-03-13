using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player
    {
        public string Name { get; private set; }
        private int health;
        private List<string> inventory = new List<string>();

        public Player(string name, int health)
        {
            Name = name;
            this.health = health;
        }

        public int GetHealth() => health;
        public void SetHealth(int value) => health = value;

        public void TakeDamage(int damage)
        {
            health -= damage;
            Console.WriteLine($"You took {damage} damage! Health is now {health}.");
            if (health <= 0)
            {
                Console.WriteLine("You have died!");
            }
        }

        public void PickUpItem(string item)
        {
            if (!string.IsNullOrEmpty(item))
            {
                inventory.Add(item);
                Console.WriteLine($"{item} has been added to your inventory.");
            }
            else
            {
                Console.WriteLine("Invalid item!");
            }
        }

        public void UseItem(string item)
        {
            if (inventory.Contains(item))
            {
                inventory.Remove(item);
                Console.WriteLine($"You used {item}.");
                if (item == "Health Potion")
                {
                    health += 20;
                    Console.WriteLine("Health restored by 20 points!");
                }
            }
            else
            {
                Console.WriteLine("You don't have that item!");
            }
        }

        public void DisplayStatus()
        {
            Console.WriteLine($"Health: {health}");
            Console.WriteLine($"Inventory: {GetInventoryContents()}");
        }

        public string GetInventoryContents() => inventory.Count > 0 ? string.Join(", ", inventory) : "Empty";
    }
}
