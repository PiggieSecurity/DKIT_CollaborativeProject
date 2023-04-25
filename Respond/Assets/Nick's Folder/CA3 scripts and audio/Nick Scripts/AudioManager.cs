using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("___Audio Source___")] 
    [SerializeField] AudioSource ambianceSource;
    [SerializeField] AudioSource outsideSource;
    [SerializeField] AudioSource bellSource;
    [SerializeField] AudioSource footstepSource;
    //[SerializeField] AudioSource epipenSource;
    [SerializeField] AudioSource dialSource;
    [SerializeField] AudioSource pickupSource;

    [Header("___Audio Clip___")] 
    public AudioClip background;
    public AudioClip outside;
    public AudioClip bell;
    public AudioClip footstep;
    //public AudioClip epipen;
    public AudioClip dial;
    public AudioClip pickup;

    private void Start()
    {
        ambianceSource.clip = background;
        outsideSource.clip = outside;
        
        ambianceSource.Play();
        outsideSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        bellSource.PlayOneShot(clip);
    }
}
    
    
    
    