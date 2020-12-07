using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public bool gameOver = false;

    public GameObject gameOverUI;

    void Start(){
        Cursor.visible = true;
    }
    
    void Update()
    {
        stopGame();
    }

    void stopGame(){
        gameOverUI.SetActive(true);
        //show the ending screen 
        
        Time.timeScale = 0f;
        //freeze game
        gameOver = true;

    }

    public void LoadMenu(){
        Debug.Log("Load menu");
    }
}
