using UnityEngine;
using System;
using UnityEngine.Audio;

public class audioManager : MonoBehaviour
{
    public Sound[] sound;

    // Start is called before the first frame update
    void Awake()
    {
        foreach (Sound item in sound)
        {
           item.source = gameObject.AddComponent<AudioSource>();
            item.source.clip = item.clip;

            item.source.volume = item.volume;
            item.source.pitch = item.pitch;
            item.source.loop = item.loop;
            
        }
    }

    public void Play(string name)
    {
       Sound s = Array.Find(sound, sound => sound.name == name);
        
        if (s == null)
        {
            Debug.Log("Sound " + name + " Not found");
            return;
        }
        else
        {
            s.source.Play();
        }
    }
    public void PlayOneShot(string name)
    {
        Sound s = Array.Find(sound, sound => sound.name == name);
        name = s.clip.name;

        if (s == null)
        {
            Debug.Log("Sound " + name + " Not found");
            return;
        }
        else
        {
            s.source.PlayOneShot(s.clip);
        }
    } 

    
    
    public void Pause(bool sound)
    {
        AudioListener.pause = sound;
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sound, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Sound " + name + " Not found");
            return;
        }
        else
        {
            s.source.Stop();
        }
        
    }
    void Update()
    {
        
    }
}
