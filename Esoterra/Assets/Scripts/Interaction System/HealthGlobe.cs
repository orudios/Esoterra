using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HealthGlobe : Pickup
{
    public override void DoAction()
    {
        Debug.Log("DoAction() in HealthGlobe class");
        base.DoAction();
    }
}
