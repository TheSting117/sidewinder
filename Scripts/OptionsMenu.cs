using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    //Defines the audioMixer that will have its volume editted
    public AudioMixer audioMixer;
    //Defines the slider that will define the volume change
    public Slider slider;
    //initialises a float that will store the value of the slider
    private float volume;

    public void SetVolume()
    {
        //Sets current slider value to the volume var, then changes the audioMixer's volume to the volume var
        volume = slider.value;
        audioMixer.SetFloat("MasterVolume", volume);
    }
}
