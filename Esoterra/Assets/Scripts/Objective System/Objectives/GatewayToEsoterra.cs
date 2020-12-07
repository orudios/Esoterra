using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GatewayToEsoterra : Objective
{
    public GameObject teleporter;


    public override void Start()
    {
        base.Start();

        teleporter = GameObject.Find("Teleporter (Olympus)");

        Name = "Gateway to Esoterra";
        Description = "Go to the storage room and repair the Blue Matter Compressor";
        Goals.Add(new RepairGoal(this, 2, "CompressorTube", "Repair 2 Blue Matter Compressor Tubes.", 0, false));
        foreach (Goal g in Goals) {
            g.Init();
        }

        ResourceRewards.Add(6);

        NotCompletedDialogue = new string[]{
            "I'm trying to command the Blue Matter Compressor, but I can't connect.",
            "You must repair the compressor tubes to allow power to flow.",
            "Go find the compressor in the storage room and make the repairs.",
            "Leave my room, head directly across the Bridge and into the curving corridor to reach the compressor."
        };

        HandInDialogue = new string[]{
            "...",
            "Connecting...",
            "...",
            "Blue Matter Compressor connection successful.",
            "Directing power flow to Bridge teleporter.",
            "I have given you Blue Matter. Insert this into the teleporter...",
            "This is your final task on Olympus.",
            "This is your gateway to Esoterra."
        };

        AlreadyCompletedDialogue = new string[]{
            "I have given you Blue Matter. Go to the Bridge just beyond my room and insert this into the teleporter.",
            "If the second teleporter remains functional, it will take you there.",
            "This is your final task on Olympus.",
            "This is your gateway to Esoterra."
        };
    }

    public override void GiveReward()
    {
        base.GiveReward();
        Debug.Log(teleporter.GetComponentInChildren<Teleporter>());
        teleporter.GetComponentInChildren<Teleporter>().enabled = true;
    }
}
