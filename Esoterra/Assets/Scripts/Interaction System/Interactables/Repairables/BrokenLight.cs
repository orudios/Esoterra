using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BrokenLight : Repairable
{
    public override void Reset()
    {
        base.Reset();
        displayName = "Light";
        requiredResources = new int[] {5, 2};
        requiredQuantity = new int[] {1, 1};
        continuousAudioWhenBroken = true;
    }

    public override void Repair()
    {
        EventManager.Repaired("BrokenLight");
        gameObject.GetComponent<FlickeringLight>().enabled = false;
        base.Repair();
    }
}
