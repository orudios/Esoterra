using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TransformRotate : MonoBehaviour
{
    [Header("Rotation Details")]
    [Tooltip("How fast to rotate on the x axis.")]
    [Range(0f, 180f)]
    public float speedXAxis = 0f;
    [Tooltip("How fast to rotate on the y axis.")]
    [Range(0f, 180f)]
    public float speedYAxis = 0f;
    [Tooltip("How fast to rotate on the z axis.")]
    [Range(0f, 180f)]
    public float speedZAxis = 20f;

    void Update()
    {
        transform.Rotate(new Vector3(speedXAxis, speedYAxis, speedZAxis) * Time.deltaTime);
    }
}
