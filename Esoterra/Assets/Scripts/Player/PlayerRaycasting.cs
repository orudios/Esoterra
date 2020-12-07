using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerRaycasting : MonoBehaviour
{
    // Camera looking
    Ray ray;
    RaycastHit hit;


    void Update()
    {
        ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public float DistanceTo(GameObject obj)
    {
        return Vector3.Distance(transform.position, obj.transform.position);
    }

    public GameObject LookingAt()
    {
        if (Physics.Raycast(ray, out hit, Mathf.Infinity)) {
            return hit.transform.gameObject;
        }
        return null;
    }
}