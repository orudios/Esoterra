using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Goal
{
    public string Description {get; set;}
    public int RequiredAmount {get; set;}
    public int CurrentAmount {get; set;}
    public bool Completed {get; set;}

    public virtual void Create()
    {
        //
    }

    public void CheckGoalCompleted()
    {
        Completed = (RequiredAmount >= CurrentAmount);
    }
}
