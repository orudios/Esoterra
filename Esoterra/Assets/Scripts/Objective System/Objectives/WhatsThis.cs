using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WhatsThis : Objective
{
    public override void Start()
    {
        base.Start();

        // Mandatory
        Name = "What's this?";
        Description = "Find some materials.";
        Goals.Add(new ResourceGoal(this, 1, 2, "Collect 1 Aluminium.", 0, false));
        Goals.Add(new ResourceGoal(this, 2, 5, "Collect 2 Copper.", 0, false));
        foreach (Goal g in Goals) {
            g.Init();
        }

        // Optional
        ResourceRewards.Add(6);
    }
}
