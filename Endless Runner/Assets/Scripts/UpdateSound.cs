using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateSound : MonoBehaviour
{
    List<AudioSource> sfx = new List<AudioSource>();

    public void Start()
    {        

        AudioSource[] allAudioSources = GameObject.FindWithTag("GameData").GetComponentsInChildren<AudioSource>();

        for(int i = 1; i < allAudioSources.Length; i++)
        {
            sfx.Add(allAudioSources[i]);
        }
        



        Slider sfxSlider = this.GetComponent<Slider>();

        if (PlayerPrefs.HasKey("SoundVolume"))
        {
            sfxSlider.value = PlayerPrefs.GetFloat("SoundVolume");
            UpdateSoundVolume(sfxSlider.value);
        }
        else
        {
            sfxSlider.value = 1f;
            UpdateSoundVolume(1f);
        }
    }

    public void UpdateSoundVolume(float value)
    {
        PlayerPrefs.SetFloat("SoundVolume", value);
        foreach (AudioSource s in sfx)
        {
            s.volume = value;
        }
    }


}
