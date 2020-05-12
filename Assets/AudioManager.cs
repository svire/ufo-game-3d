using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;  //array.fnd

public class AudioManager : MonoBehaviour {


    public Sound[] sounds;
  

    //loop for a lisst and for a each sound loop audio source 


	void Awake()
    {
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }
    void Start()
    {
        Play("voznja");
    }
	
	
	public void Play(string name)
    {
        Sound s=Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }
}
