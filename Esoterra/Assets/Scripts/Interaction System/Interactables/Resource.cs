using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Resource : Interactable
{
    [Header("Resource Details")]
    public int ID;
    public int atomicNumber;
    public string symbol;

    [HideInInspector] public Inventory inventory;


    void Reset()
    {
        interactionVerb = "Collect";
    }

    public override void Start()
    {
        base.Start();
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Inventory>();
    }

    public override void Interact()
    {
        inventory.AddResource(ID, 1);
        Destroy(transform.parent.gameObject);
    }
}
