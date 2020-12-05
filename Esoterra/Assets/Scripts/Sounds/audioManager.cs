using UnityEngine.Audio;
using UnityEngine;
using System;

public class audioManager : MonoBehaviour
{
    public sound[] sounds;

    // Start is called before the first frame update
    void Awake()
    { 
        //adding sounds to the sound[] array
        foreach (sound s in sounds){
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume=s.volume;
            s.source.pitch=s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Play (string name){
        sound s = Array.Find(sounds,sound => sound.soundName == name);
        if (s==null){
            Debug.LogWarning("Sound: " + name + " not found"); //if theres a typo in the sound name
        }
        //s.source.PlayDelayed(0.1f);
        s.source.PlayOneShot(s.clip,1f);
    }
    
}
