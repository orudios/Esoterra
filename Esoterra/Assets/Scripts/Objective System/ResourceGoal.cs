using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ResourceGoal : Goal
{
    public int TrackingResourceID {get; set;}


    public ResourceGoal(Objective objective, int requiredAmount, int trackingResourceID, string description, int currentAmount, bool completed)
    {
        this.Objective = objective;
        this.RequiredAmount = requiredAmount;
        this.TrackingResourceID = trackingResourceID;
        this.Description = description;
        this.CurrentAmount = currentAmount;
        this.Completed = completed;
    }

    public override void Init()
    {
        base.Init();
        EventManager.OnResourceCollect += ResourceCollected;
    }

    public void ResourceCollected(int resID)
    {
        if (resID == this.TrackingResourceID) {
            this.CurrentAmount++;
            CheckGoalComplete();
        }
    }
}
