using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Rotatez : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 70) * Time.deltaTime);
    }

}
