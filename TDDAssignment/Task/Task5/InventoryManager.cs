using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDAssignment.Task.Task5
{
    public class InventoryManager
    {
        private Dictionary<string, int> inventory;

        public InventoryManager()
        {
            inventory = new Dictionary<string, int>();
        }
        public void AddItem(string itemName, int quantity)
        {
            if (string.IsNullOrEmpty(itemName))
            {
                throw new ArgumentException("Item name cannot be null or empty.", nameof(itemName));
            }

            if (quantity < 0)
            {
                throw new ArgumentException("Quantity cannot be negative.", nameof(quantity));
            }

            if (inventory.ContainsKey(itemName))
            {
                inventory[itemName] += quantity;
            }
            else
            {
                inventory[itemName] = quantity; // Lägg till ny artikel med kvantitet
            }
        }

        public void RemoveItem(string itemName, int quantity)
        {
           if(string.IsNullOrEmpty(itemName))
            {
                throw new ArgumentException(nameof(itemName), "Item can not be null");
            }
            if (quantity <= 0)
            {
                throw new ArgumentException(nameof(quantity), "Quantity can not be less than 0");
            }
            if (!inventory.ContainsKey(itemName))
            {
                throw new InvalidOperationException($"'{itemName}' not found in inventory.");
            }
            if (inventory[itemName] < quantity)
            {
                throw new InvalidOperationException($"Not enough quantity of '{itemName}' to remove. Available: {inventory[itemName]}.");
            }

            inventory[itemName] -= quantity;

            if (inventory[itemName] == 0)
            {
                inventory.Remove(itemName);
            }
        }
        public List<string> GetOutOfStockItems()
        {
            var outOfStockItems = new List<string>();

            foreach (var item in inventory)
            {
                if (item.Value == 0)
                {
                    outOfStockItems.Add(item.Key);
                }
            }

            return outOfStockItems;
        }

        public int GetQuantity(string itemName)
        {
            if (inventory.ContainsKey(itemName))
            {
                return inventory[itemName];
            }
            return 0;
        }
    }
}
