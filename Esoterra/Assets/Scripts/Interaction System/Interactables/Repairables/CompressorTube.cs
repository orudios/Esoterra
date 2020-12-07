using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CompressorTube : Repairable
{
    public ParticleSystem particles;
    public GameObject otherTube;
    public GameObject compressorActivateOnRepair;


    public override void Reset()
    {
        base.Reset();
        displayName = "Compressor Tube";
        requiredResources = new int[] {1, 3, 4, 6};
        requiredQuantity = new int[] {2, 1, 1, 1};
        continuousAudioWhenBroken = false;
    }

    public override void Awake()
    {
        base.Awake();
        particles.gameObject.SetActive(false);
    }

    public override void Repair()
    {
        EventManager.Repaired("CompressorTube");
        base.Repair();
        particles.gameObject.SetActive(true);

        // Check the other tube. If it's not broken, then start the compressor!
        if (!otherTube.gameObject.GetComponent<Repairable>().broken) {
            compressorActivateOnRepair.SetActive(true);
        }
    }
}
