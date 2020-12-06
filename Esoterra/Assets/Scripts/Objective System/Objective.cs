using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Objective : MonoBehaviour
{
    // Mandatory to set in subclass
    public string Name {get; set;}
    public string Description {get; set;}
    public List<Goal> Goals {get; set;} = new List<Goal>();

    // Optional to change in subclass
    public List<int> ResourceRewards {get; set;} = new List<int>();
    public string[] NotCompletedDialogue {get; set;} = new string[]{
        "You haven't completed the objective.",
        "Here's your progress right now..."};
    public string[] JustCompletedDialogue {get; set;} = {"You have completed the objective!"};
    public string[] CompletedDialogue {get; set;} = {"You have already completed this objective."};

    public bool Completed {get; set;}

    Inventory inventory;


    public virtual void Start()
    {
        inventory =
            GameObject.FindGameObjectWithTag("Player")
            .GetComponentInChildren<Inventory>();
    }

    // Return an array of the Goals and their progress to be used in dialogue
    public string[] GoalsStrings()
    {
        List<string> goalsStrings = new List<string>();
        foreach (Goal g in Goals) {
            goalsStrings.Add(g.Description + " (" + g.CurrentAmount + "/" + g.RequiredAmount + ")");
        }
        return goalsStrings.ToArray();
    }

    // Return an array of Goals and their progress, along with some dialogue to show first
    public string[] GoalsStrings(string[] initialDialogue)
    {
        List<string> goalsStrings = new List<string>();
        foreach (string dialogue in initialDialogue) {
            goalsStrings.Add(dialogue);
        }
        foreach (Goal g in Goals) {
            goalsStrings.Add(g.Description + " (" + g.CurrentAmount + "/" + g.RequiredAmount + ")");
        }
        return goalsStrings.ToArray();
    }
    
    public void CheckGoalsCompleted()
    {
        foreach (Goal g in Goals) {
            if (g.Completed == false) {
                Completed = false;
                return;
            }
        }
        Completed = true;
        return;
    }

    public virtual void GiveReward()
    {
        // Add resource rewards to player inventory
        if (ResourceRewards.Count != 0) {
            foreach (int resID in ResourceRewards) {
                inventory.AddResource(resID, 1);
            }
        }
    }
}
