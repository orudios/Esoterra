using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class Objective
{
    public List<Goal> Goals {get; set;} = new List<Goal>();

    public string ID {get; set;}
    public string Name {get; set;}
    public string Description {get; set;}
    public bool Completed {get; set;}

    public void CheckGoalsCompleted()
    {
        Completed = (Goals.All(goal => goal.Completed));
    }
}
