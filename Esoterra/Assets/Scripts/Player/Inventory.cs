using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Store Resource IDs and their quantity
    Dictionary<int, int> inventory = new Dictionary<int, int>();

    // Audio
    AudioSource[] audioSources;
    AudioSource audioCollectResource;

    
    void Awake()
    {
        audioSources = gameObject.GetComponents<AudioSource>();
        ConfigureAudio();
    }

    void ConfigureAudio()
    {
        if (audioSources.Length > 0) {
            audioCollectResource = audioSources[0];
        }
    }
    
    public int Quantity(int ID)
    {
        // If this resource is in the dictionary, return the quantity
        if (inventory.ContainsKey(ID)) {
            return inventory[ID];
        // Otherwise, dictionary doesn't contain the resource
        } else {
            return 0;
        }
    }
    
    public void AddResource(int ID, int amount)
    {
        // None of this resource: add the new resource and amount to dictionary
        if (Quantity(ID) == 0) {
            inventory.Add(ID, amount);
        // Otherwise, increase the quantity
        } else {
            inventory[ID] += amount;
        }
        EventManager.ResourceCollected(ID);

        if (audioCollectResource != null) {
            audioCollectResource.Play();
        }
    }

    public bool RemoveResource(int ID, int amount)
    {
        // None of this resource: failure; no change
        if (Quantity(ID) == 0) {
            return false;
        // Exact amount: success; completely remove the resource from dictionary
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
