using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer AudioMixer;
    [SerializeField] private Slider ambianceSlider;
    private void Start()
    {
        if (PlayerPrefs.HasKey("ambianceVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMusicVolume();
        }
        
    }
    public void SetMusicVolume()
    {
        float volume = ambianceSlider.value;
        AudioMixer.SetFloat("Ambiance", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("ambianceVolume", volume);
    }
    private void LoadVolume()
    {
        ambianceSlider.value = PlayerPrefs.GetFloat("ambianceVolume");
        
        SetMusicVolume();
    }
}