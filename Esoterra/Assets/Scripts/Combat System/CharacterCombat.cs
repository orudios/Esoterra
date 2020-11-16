using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour
{
    CharacterStats myStats;

    public float attackSpeed = 1f;
    //prevents repeated attack
    
    void Start(){
        myStats=GetComponent<CharacterStats>();

    }
    public void Attack (CharacterStats targetStats){
        targetStats.TakeDamage(myStats.damage.GetValue());
    }
}
