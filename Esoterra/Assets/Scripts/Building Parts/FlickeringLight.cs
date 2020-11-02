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

    // Code governing light flickering. Defines a random number for the flickerTimer that decrements and shuts the lights off/on accordingly
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
