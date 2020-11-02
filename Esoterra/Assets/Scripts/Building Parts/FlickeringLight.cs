using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLight : MonoBehaviour
{
    public Light _light;

    public float minFlickerTime;
    public float maxFlickerTime;
    public float flickerTimer;

    void Update()
    {
        FlickerLight();
    }

    void FlickerLight() 
    {
        if (flickerTimer > 0)
        {
            flickerTimer -= Time.deltaTime;
        }

        if (flickerTimer <= 0) 
        {
            _light.enabled = !_light.enabled;
            flickerTimer = Random.Range(minFlickerTime, maxFlickerTime);
        }
    }
}
