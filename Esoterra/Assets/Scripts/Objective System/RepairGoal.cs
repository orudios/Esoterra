using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RepairGoal : Goal
{
    public GameObject repairableObject;
    public List<KeyValuePair<IResource, int>> RequiredResources {get; set;} = new List<KeyValuePair<IResource, int>>();

    public RepairGoal(Objective objective, GameObject repairableObject, List<KeyValuePair<IResource, int>> requiredResources, string description, bool completed)
    {
        this.Objective = objective;
        this.repairableObject = repairableObject;
        this.RequiredResources = requiredResources;

        this.Description = description;
        this.Completed = completed;
    }

    public override void Create()
    {
        base.Create();
        this.RequiredAmount = 1;
        this.CurrentAmount = 0;

        // EventController.OnObjectRepair += ObjectRepaired;
    }

    public void ObjectRepaired(GameObject obj)
    {
        if (obj == this.repairableObject)
        {
            this.CurrentAmount++;
            CheckGoalCompleted();
        }
    }
}
