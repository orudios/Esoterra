using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

}
