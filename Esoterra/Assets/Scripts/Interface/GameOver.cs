using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public bool gameOver = false;
    public playerHealth health;

    public GameObject gameOverUI;

    void Start(){
        gameOverUI.SetActive(false);
        //hide the menu
    }
    void Update()
    {
        if (health.health<=0){
            //if the player is dead
            Debug.Log("Stopping game");
            stopGame();
        }
    }

    void stopGame(){
        gameOverUI.SetActive(true);
        //show the ending screen

        //Cursor.lockState = CursorLockMode.None;
        
        Time.timeScale = 0f;
        //freeze game
        gameOver = true;

    }

    public void LoadMenu(){
        Debug.Log("Load menu");
    }
}
