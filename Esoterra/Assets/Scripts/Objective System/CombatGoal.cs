using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CombatGoal : Goal
{
    public int TrackingEnemyID {get; set;}

    public CombatGoal(Objective objective, int trackingEnemyID, string description, int requiredAmount, int currentAmount, bool completed)
    {
        this.TrackingEnemyID = trackingEnemyID;
        this.Description = description;
        this.RequiredAmount = requiredAmount;
        this.CurrentAmount = currentAmount;
        this.Completed = completed;
    }

    public override void Create()
    {
        base.Create();

        // TODO listener for all goal subtype events
        // EventController.OnEnemyDeath += EnemyDied;
    }

    public void EnemyDied(IEnemy enemy)
    {
        if (enemy.ID == this.TrackingEnemyID)
        {
            this.CurrentAmount++;
            CheckGoalCompleted();
        }
    }
}
