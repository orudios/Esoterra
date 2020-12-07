using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BrokenLight : Repairable
{
    // The light source to turn on
    Light myLight;

    // Materials for light when off and on
    Material baseMaterial;
    Material lightMaterial;


    public override void Reset()
    {
        base.Reset();
        displayName = "Light";
        requiredResources = new int[] {5, 2};
        requiredQuantity = new int[] {1, 1};
        continuousAudioWhenBroken = true;
    }

    public override void Awake()
    {
        base.Awake();

        // Get own components
        myLight = gameObject.transform.GetChild(0).GetComponent<Light>();
        baseMaterial = gameObject.GetComponent<MeshRenderer>().materials[0];
        lightMaterial = gameObject.GetComponent<MeshRenderer>().materials[1];
    }

    public override void Repair()
    {
        EventManager.Repaired("BrokenLight");

        // Disable flickering script
        gameObject.GetComponent<LightFlicker>().enabled = false;

        // Enable lights
        myLight.enabled = true;
        gameObject.GetComponent<MeshRenderer>().materials = new Material[]{
            baseMaterial, lightMaterial
        };

        base.Repair();
    }
}
