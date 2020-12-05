using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headBobbing : MonoBehaviour
{
    private float timer = 0.0f;

    public float speed;
    public float amount;
    public float midpoint;

    private float waveslice;

    private float translateChange;

    private float totalAxes;
    void Update()
    {
        waveslice = 0.0f;
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");

        if (Mathf.Abs(horizontalAxis) ==0 && Mathf.Abs(verticalAxis) ==0){
            timer = 0.0f;
        }
        else{
            waveslice = Mathf.Sin(timer);
            timer = timer + speed;

            if (timer > Mathf.PI * 2){
                timer = timer - (Mathf.PI * 2);
            }
        }
        if (waveslice !=0){
            translateChange = waveslice*amount;
            totalAxes = Mathf.Abs(horizontalAxis) + Mathf.Abs(verticalAxis);
            totalAxes = Mathf.Clamp(totalAxes, 0.0f, 1.0f);
            translateChange = totalAxes * translateChange;
            // Vector3 temp =transform.localPosition;
            // temp.y=5f;
            transform.position=new Vector3(transform.position.x,midpoint + translateChange,transform.position.z);

            //transform.localPosition.y = midpoint + translateChange;
            //Debug.Log("BOBBY");

        }
        else{
            // when the player lifts up the key, the camera goes back to the normal y positon
            // and stops bobbing
            transform.position = new Vector3(transform.position.x,midpoint,transform.position.z);
        }
    }
}
