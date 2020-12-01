using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour
{
    CharacterStats myStats;

    public float attackSpeed = 1f;
    //prevents repeated attack
    private float attackCooldown = 0f;

    void Update(){

        attackCooldown -=Time.deltaTime;
        //cooldown decreasing over time when not attacking
    }
        

    
    void Start(){
        myStats=GetComponent<CharacterStats>();

    }
    public void Attack (CharacterStats targetStats){

        if (attackCooldown<=0f){
            targetStats.TakeDamage(myStats.damage.GetValue());
            attackCooldown=1f/attackSpeed;
            //the bigger the attack speed, the smaller the cooldown
        }
        
    }
}
