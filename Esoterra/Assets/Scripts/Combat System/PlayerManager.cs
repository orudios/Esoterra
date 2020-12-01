using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerManager : MonoBehaviour
{
   //singleton pattern
   #region Singleton
   
   public static PlayerManager instance;

   void Awake(){
       instance = this;
   }

   #endregion

    public GameObject player;

    public void KillPlayer(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //reloads current scene when player dies
    }
}
