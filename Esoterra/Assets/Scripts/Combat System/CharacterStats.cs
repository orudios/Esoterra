
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public Stat damage;

    public int maxHealth = 100;
    public int currentHealth {get; private set;}
    //this means that any other class can get this value
    //but we can only set this here

    void Awake(){
        currentHealth = maxHealth;
    }

    void Update(){

        
    }

    public void TakeDamage(int damage){

        currentHealth-=damage;

        if (currentHealth<=0){
            Die();
        }
    }

    public virtual void Die(){
        //this method will be overwritten
    }
}
