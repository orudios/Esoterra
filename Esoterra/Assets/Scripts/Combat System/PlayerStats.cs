using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    public override void Die()
    {
        base.Die();
        // player dies
        Debug.Log("player has died");
        PlayerManager.instance.KillPlayer();

    }
}
