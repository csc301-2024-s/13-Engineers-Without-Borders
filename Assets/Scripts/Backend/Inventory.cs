using System.Collections.Generic;
using UnityEngine;

// Original Author: Andy Wang
// This class represents a household's inventory of items in storage.
namespace Backend
{
    /// <summary>
    /// A household's inventory. Can store items.
    /// </summary>
    public class Inventory : HouseholdAsset
    {
        private Dictionary<string, int> _items;

        /// <summary>
        /// Creates an empty inventory.
        /// </summary>
        public Inventory()
        {
            _items = new();
        }

        /// <summary>
        /// Adds <paramref name="newItem"/> to the inventory. If it already exists, increment its count.
        /// </summary>
        /// <param name="newItem">The item to add.</param>
        public void AddItem(string newItem)
        {
            if (_items.ContainsKey(newItem))
            {
                _items[newItem]++;
                return;
            }

            _items.Add(newItem, 1);
        }

        /// <summary>
        /// Removes one <paramref name="item"/> from the inventory. If it exists, decrement its count. If its count becomes 0, remove the key entry.
        /// If it doesn't exist, log a message in the Unity console.
        /// </summary>
        /// <param name="item">The item to remove.</param>
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

        /// <summary>
        /// Gets the count of <paramref name="item"/> in the inventory.
        /// </summary>
        /// <param name="item">Item to count.</param>
        /// <returns>Count of item in inventory, 0 if none.</returns>
        public int GetAmount(string item)
        {
            if (_items.ContainsKey(item))
            {
                return _items[item];
            }

            return 0;
        }

        /// <summary>
        /// Check if <paramref name="item"/> is in the inventory.
        /// </summary>
        /// <param name="item">The item to look for.</param>
        /// <returns>Whether the item is in the inventory.</returns>
        public bool Contains(string item) {
            return _items.ContainsKey(item);
        }
    }
}