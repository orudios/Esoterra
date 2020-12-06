using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EventManager : MonoBehaviour
{
    // ResourceGoals
    public delegate void ResourceEventHandler(int resID);
    public static event ResourceEventHandler OnResourceCollect;
    public static void ResourceCollected(int resID)
    {
        if (OnResourceCollect != null) {
            OnResourceCollect(resID);
        }
    }
}
