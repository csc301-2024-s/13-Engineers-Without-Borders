using System.Collections.Generic;
using UnityEngine;

/*
 * Author: Andy Wang
 * This class represents a household's inventory of items in storage.
 */
namespace Backend
{
    public class Inventory
    {
        private Dictionary<string, int> _items;

        // Create a new empty inventory
        public Inventory()
        {
            _items = new Dictionary<string, int>();
        }

        // Adds <newItem> to the inventory. If it already exists, increment its count.
        public void AddItem(string newItem)
        {
            if (_items.ContainsKey(newItem))
            {
                _items[newItem]++;
                return;
            }

            _items.Add(newItem, 1);
        }

        // Removes a <item> from the inventory. If it exists, decrement its count. If its count becomes 0, remove the key entry.
        // Log an error if the item doesn't exist.
        public void RemoveItem(string item)
        {
            if (_items.ContainsKey(item))
            {
                _items[item]--;

                if (_items[item] == 0)
                {
                    _items.Remove(item);
                }
                return;
            }

            Debug.Log("Trying to remove item that doesn't exist in inventory: " + item);
        }

        // Gets the count of a certain item in the inventory
        // Log an error and return -1 if item doesn't exist.
        public int GetAmount(string item)
        {
            if (_items.ContainsKey(item))
            {
                return _items[item];
            }

            Debug.Log("Trying to get item that doesn't exist in inventory: " + item);
            return -1;
        }

        // Sees if <item> is in the inventory
        public bool Contains(string item) {
            return _items.ContainsKey(item);
        }
    }
}