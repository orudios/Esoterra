using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MS01 : Objective
{
    // Start is called before the first frame update
    void Start()
    {
        ID = "MS01";
        Name = "Alien Onboard";
        Description = "Deal with the source of the noise in the medbay.";

        // Goal definitions
        // In this case, just one, but can have however many we need
        Goals.Add(new CombatGoal(this, 0, "Kill the alien.", 1, 0, false));

        Goals.ForEach(goal => goal.Create());
    }
}
