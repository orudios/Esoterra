using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Goal
{
    public Objective Objective {get; set;}
    
    public string Description {get; set;}
    public int RequiredAmount {get; set;}
    public int CurrentAmount {get; set;}
    public bool Completed {get; set;}

    public virtual void Create(){}

    public void CheckGoalCompleted()
    {
        if (RequiredAmount >= CurrentAmount)
        {
            Complete();
        }
    }

    public void Complete()
    {
        Completed = true;
        Debug.Log(Objective.ID + " goal completed: " + Description);
        Objective.CheckGoalsCompleted();
    }
}
