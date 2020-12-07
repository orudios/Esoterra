using UnityEngine.Audio;
using UnityEngine;

[System.Serializable] //shows the class in inspector
public class sound
{
    public string soundName;
    public AudioClip clip;
    
    [Range(0f,1f)] //minimum and maximum value for volume 
    public float volume;

    [Range(0.1f,3f)]
    public float pitch;

    public bool loop;
   
    [HideInInspector]
    public AudioSource source;

}
