using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectiveProvider : MonoBehaviour
{
    public Objective objective;

    PlayerController playerController;


    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("PlayerController").GetComponent<PlayerController>();
    }


    public void AssignObjective()
    {
        // playerController.objectives.Add(objective);
        // Debug.Log(gameObject.name + " has given player objective " + objective.ID + " " + objective.Name);
    }

}
