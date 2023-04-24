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
    [SerializeField] private Slider SFXSlider;
    private void Start()
    {
        if (PlayerPrefs.HasKey("ambianceVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMusicVolume();
            SetSFXVolume();
        }
        
    }
    public void SetMusicVolume()
    {
        float volume = ambianceSlider.value;
        AudioMixer.SetFloat("Ambiance", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("ambianceVolume", volume);
    }
    public void SetSFXVolume()
    {
        float volume = SFXSlider.value;
        AudioMixer.SetFloat("SFX", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }
    private void LoadVolume()
    {
        ambianceSlider.value = PlayerPrefs.GetFloat("ambianceVolume");
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        
        SetMusicVolume();
        SetSFXVolume();
    }
}