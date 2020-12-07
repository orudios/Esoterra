using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class playerHealth : MonoBehaviour
{
    public float health;

    public void receiveDamage(float damage)
    {
        health -= damage;
        //Debug.Log(health);
        if (health <= 0f)
        {
            Cursor.lockState = CursorLockMode.None;
            
            SceneManager.LoadScene("GameOverScene",LoadSceneMode.Single);
            //Cursor.visible = true;
        }
    }
    

    

    
}
