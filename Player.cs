using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player
    {
        public string Name { get; private set; }
        public int Health { get; private set; }
        private List<string> inventory = new List<string>();

        public Player(string name, int health)
        {
            Name = name;
            Health = health;
        }

        public void PickUpItem(string item)
        {
            if (!string.IsNullOrEmpty(item))
            {
                inventory.Add(item);
                Console.WriteLine($"You picked up: {item}");
            }
            else
            {
                Console.WriteLine("There is no item to pick up.");
            }
        }

        public string InventoryContents()
        {
            if (inventory.Count == 0)
            {
                return "Your inventory is empty.";
            }
            return $"Inventory: {string.Join(", ", inventory)}";
        }

        public void TakeDamage(int damage)
        {
            if (damage > 0)
            {
                Health -= damage;
                if (Health < 0)
                {
                    Health = 0;
                }
                Console.WriteLine($"You took {damage} damage! Health is now {Health}.");
            }
        }

        public void Heal(int amount)
        {
            if (amount > 0)
            {
                Health += amount;
                Console.WriteLine($"You healed {amount} points! Health is now {Health}.");
            }
        }

        public bool IsAlive()
        {
            return Health > 0;
        }
    }
}