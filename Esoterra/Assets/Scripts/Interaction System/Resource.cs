using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Resource : Item
{
    [Header("Resource Details")]
    public int atomicNumber;
    public string symbol;

    Inventory inventory;


    void Reset()
    {
        interactionDistance = 4f;
        interactionVerb = "Collect";
    }

    public override void Start()
    {
        base.Start();
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    public override void Interact()
    {
        // Audio
        base.Interact();

        inventory.AddItem(ID, 1);
        Destroy(transform.parent.gameObject);
    }
}
