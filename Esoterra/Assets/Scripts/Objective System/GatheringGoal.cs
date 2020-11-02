using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GatheringGoal : Goal
{
    public int TrackingResourceID {get; set;}

    public GatheringGoal(Objective objective, int trackingResourceID, string description, int requiredAmount, int currentAmount, bool completed)
    {
        this.Objective = objective;
        this.TrackingResourceID = trackingResourceID;

        this.Description = description;
        this.RequiredAmount = requiredAmount;
        this.CurrentAmount = currentAmount;
        this.Completed = completed;
    }

    public override void Create()
    {
        base.Create();

        // EventController.OnResourceGather += ResourceGathered;
    }

    public void ResourceGathered(IResource resource)
    {
        if (resource.ID == this.TrackingResourceID)
        {
            this.CurrentAmount++;
            CheckGoalCompleted();
        }
    }
}
