using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateMusic : MonoBehaviour
{
    List<AudioSource> music = new List<AudioSource>();
    void Start()
    {
        AudioSource[] allAudioSources = GameObject.FindWithTag("GameData").GetComponentsInChildren<AudioSource>();
        music.Add(allAudioSources[0]);
    }

    public void UpdateMusicVolume(float value)
    {
        foreach(AudioSource m in music)
        {
            m.volume = value;
        }
    }
}
