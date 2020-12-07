using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EventManager : MonoBehaviour
{
    // ResourceGoal
    public delegate void ResourceEventHandler(int resID);
    public static event ResourceEventHandler OnResourceCollect;

    // RepairGoal
    public delegate void RepairEventHandler(string repairableType);
    public static event RepairEventHandler OnRepair;


    public static void ResourceCollected(int resID)
    {
        if (OnResourceCollect != null) {
            OnResourceCollect(resID);
        }
    }
    
    public static void Repaired(string repairableType)
    {
        if (OnRepair != null) {
            OnRepair(repairableType);
        }
    }
}
