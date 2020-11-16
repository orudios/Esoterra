using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class Enemy : InteractableEnemy
{
    PlayerManager playerManager;
    CharacterStats myStats;
    void Start(){
        playerManager=PlayerManager.instance;
        myStats = GetComponent<CharacterStats>();
    }
   public override void Interact(){
       base.Interact();
       // attack the enemy

       CharacterCombat playerCombat =  playerManager.player.GetComponent<CharacterCombat>();
       if (playerCombat !=null){
           playerCombat.Attack(myStats);
       }
   }

    
}
