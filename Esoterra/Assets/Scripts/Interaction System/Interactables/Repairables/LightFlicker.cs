using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LightFlicker : MonoBehaviour
{
    [Tooltip("The light source to turn on and off.")]
    public Light myLight;
    [Tooltip("Minimum time between light flickers.")]
    public float minFlickerTime;
    [Tooltip("Maximum time between light flickers.")]
    public float maxFlickerTime;

    // Materials for light when off and on
    Material baseMaterial;
    Material lightMaterial;

    // A random amount between min and max to determine time between on/off state
    float flickerTimer;


    void Awake()
    {
        // Get own components
        baseMaterial = gameObject.GetComponent<MeshRenderer>().materials[0];
        lightMaterial = gameObject.GetComponent<MeshRenderer>().materials[1];
    }

    void Update()
    {
        Flicker();
    }

    void Flicker() 
    {
        // Decrement the timer
        if (flickerTimer > 0) {
            flickerTimer -= Time.deltaTime;
        }
        // Trigger change in on/off state when timer runs out
        if (flickerTimer <= 0) {
            myLight.enabled = !myLight.enabled;
            SwapMaterial();
            flickerTimer = Random.Range(minFlickerTime, maxFlickerTime);
        }
    }

    void SwapMaterial()
    {
        // If the light should be "on", use the light material
        if (myLight.enabled) {
            gameObject.GetComponent<MeshRenderer>().materials = new Material[]{
                baseMaterial, lightMaterial
            };
        }
        // Otherwise, use the base material to hide the light looking part
        else {
            gameObject.GetComponent<MeshRenderer>().materials = new Material[]{
                baseMaterial, baseMaterial
            };
        }
    }
}
