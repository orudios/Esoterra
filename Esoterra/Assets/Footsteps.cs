using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    CharacterController cc;
    AudioSource footstepAudio;

    void Start()
    {
        cc = GetComponent<CharacterController>();
        footstepAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (cc.isGrounded == true && cc.velocity.magnitude > 0.1f && footstepAudio.isPlaying == false)
        {
            footstepAudio.volume = Random.Range(0.8f, 1);
            footstepAudio.pitch = Random.Range(0.8f, 1.1f);
            footstepAudio.Play();
            Debug.Log(cc.isGrounded);
        }
    }
}