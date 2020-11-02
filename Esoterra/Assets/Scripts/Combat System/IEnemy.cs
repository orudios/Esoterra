using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IEnemy
{
    int ID {get; set;}
    void DealDamage(int amount);
    void ReceiveDamage(int amount);
}
