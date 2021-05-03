using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateMusic : MonoBehaviour
{
    List<AudioSource> music = new List<AudioSource>();
    void Start()
    {

        AudioSource[] allAudioSources = GameObject.FindWithTag("GameData").GetComponentsInChildren<AudioSource>();
        music.Add(allAudioSources[0]);

        Slider musicSlider = this.GetComponent<Slider>();

        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
            UpdateMusicVolume(musicSlider.value);
        }
        else
        {
            musicSlider.value = 1f;
            UpdateMusicVolume(1f);
        }
    }

    public void UpdateMusicVolume(float value)
    {
        PlayerPrefs.SetFloat("MusicVolume", value);
        foreach(AudioSource m in music)
        {
            m.volume = value;
        }
    }
}
