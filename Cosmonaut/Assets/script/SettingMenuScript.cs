using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingMenuScript : MonoBehaviour
{

    public AudioMixer mixer;
    private mouseLook Mouse;

    float s;

    private void Start()
    {
         
    }
    public void setVolume(float volume)
    {
        mixer.SetFloat("Volume", volume);
    }

    public void SetSensitivity(float sens)
    {
        Mouse = GameObject.FindGameObjectWithTag("cam").GetComponent<mouseLook>();
        Mouse.mouseSensitivity = sens;
        
        Debug.Log(sens);
    }
}
