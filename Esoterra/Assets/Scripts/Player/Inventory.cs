using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Store Item IDs and their quantity
    Dictionary<int, int> inventory = new Dictionary<int, int>();

    public int Quantity(int id)
    {
        // If this item is in the inventory, return the quantity
        if (inventory.ContainsKey(id)) {
            return inventory[id];
        // Otherwise, inventory doesn't contain the item
        } else {
            return 0;
        }
    }
    
    public void Add(int id, int amount)
    {
        // None of this item: add the new item and amount to inventory
        if (Quantity(id) == 0) {
            inventory.Add(id, amount);
        // Otherwise, increase the quantity
        } else {
            inventory[id] += amount;
        }
    }

    public bool Remove(int id, int amount)
    {
        // None of this item: failure; no change
        if (Quantity(id) == 0) {
            return false;
        // Exact amount: success; completely remove the item from inventory
        } else if (Quantity(id) == amount) {
            inventory.Remove(id);
            return true;
        // Otherwise: success; decrease the quantity
        } else {
            inventory[id] -= amount;
            return true;
        }
    }
}
