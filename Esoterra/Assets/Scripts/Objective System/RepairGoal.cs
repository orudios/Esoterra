using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RepairGoal : Goal
{
    public string TrackingRepairType {get; set;}


    public RepairGoal(Objective objective, int requiredAmount, string trackingRepairType, string description, int currentAmount, bool completed)
    {
        this.Objective = objective;
        this.RequiredAmount = requiredAmount;
        this.TrackingRepairType = trackingRepairType;
        this.Description = description;
        this.CurrentAmount = currentAmount;
        this.Completed = completed;
    }

    public override void Init()
    {
        base.Init();
        EventManager.OnRepair += Repaired;
    }

    public void Repaired(string repairableType)
    {
        if (repairableType == this.TrackingRepairType) {
            this.CurrentAmount++;
            CheckGoalComplete();
        }
    }
}
