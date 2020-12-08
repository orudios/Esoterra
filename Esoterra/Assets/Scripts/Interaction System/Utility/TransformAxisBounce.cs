using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TransformAxisBounce : MonoBehaviour
{
    [Header("Bounce Details")]
    [Tooltip("Which axis to bounce on.")]
    public string axis = "y";
    [Tooltip("How far to travel along the axis.")]
    [Range(0f, 10f)]
    public float distance = 1f;
    [Tooltip("How fast to bounce on the axis.")]
    [Range(0f, 10f)]
    public float speed = 5f;

    Vector3 initialPosition;
	
	
    void Start()
    {
        initialPosition = transform.position;
        axis = axis.ToLower();
    }

    void Update()
    {
        switch (axis) {
            case "x":
                transform.position = new Vector3(
                    Mathf.Sin(Time.time * speed) * distance + initialPosition.x,
                    transform.position.y,
                    transform.position.z
                );
                break;

            case "y":
                transform.position = new Vector3(
                    transform.position.x,
                    Mathf.Sin(Time.time * speed) * distance + initialPosition.y,
                    transform.position.z
                );
                break;

            case "z":
                transform.position = new Vector3(
                    transform.position.x,
                    transform.position.y,
                    Mathf.Sin(Time.time * speed) * distance + initialPosition.z
                );
                break;
        }
    }
}
