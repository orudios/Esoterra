using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// TODO
// Position of Pickup in hierarchy on Instantiate()
// https://stackoverflow.com/a/59711160


public class Pickup : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")){
            DoAction();
        }
    }

    public virtual void DoAction()
    {
        Debug.Log("DoAction() in Pickup class");
        Destroy(gameObject);
    }
}
