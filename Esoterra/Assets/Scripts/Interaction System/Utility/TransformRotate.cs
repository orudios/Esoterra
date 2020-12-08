using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TransformRotate : MonoBehaviour
{
    [Header("Rotation Details")]
    [Tooltip("How fast to rotate around the x axis.")]
    [Range(-180f, 180f)]
    public float xAxisSpeed = 0f;
    [Tooltip("How fast to rotate around the y axis.")]
    [Range(-180f, 180f)]
    public float yAxisSpeed = 0f;
    [Tooltip("How fast to rotate around the z axis.")]
    [Range(-180f, 180f)]
    public float zAxisSpeed = 20f;


    void Update()
    {
        transform.Rotate(new Vector3(xAxisSpeed, yAxisSpeed, zAxisSpeed) * Time.deltaTime);
    }
}
