using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Store Item IDs and their quantity
    Dictionary<int, int> inventory = new Dictionary<int, int>();

    public int Quantity(int ID)
    {
        // If this item is in the dictionary, return the quantity
        if (inventory.ContainsKey(ID)) {
            return inventory[ID];
        // Otherwise, dictionary doesn't contain the item
        } else {
            return 0;
        }
    }
    
    public void AddItem(int ID, int amount)
    {
        // None of this item: add the new item and amount to dictionary
        if (Quantity(ID) == 0) {
            inventory.Add(ID, amount);
        // Otherwise, increase the quantity
        } else {
            inventory[ID] += amount;
        }
    }

    public bool RemoveItem(int ID, int amount)
    {
        // None of this item: failure; no change
        if (Quantity(ID) == 0) {
            return false;
        // Exact amount: success; completely remove the item from dictionary
        } else if (Quantity(ID) == amount) {
            inventory.Remove(ID);
            return true;
        // Otherwise: success; decrease the quantity
        } else {
            inventory[ID] -= amount;
            return true;
        }
    }
}
