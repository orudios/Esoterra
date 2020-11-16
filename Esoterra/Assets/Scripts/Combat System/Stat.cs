using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
//the fields will show up in the inspector
public class Stat
{
    [SerializeField]
    private int baseValue;

    public int GetValue(){
        //to access in inspector
        return baseValue;
    }
    
}
