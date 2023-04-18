using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeSound : MonoBehaviour
{
    public AudioSource Audiosource;
    private bool hasplayed =false;
    private void OnTriggerEnter(Collider other)
    {
        if (!Audiosource.isPlaying && !hasplayed)
        {
            Audiosource.Play();
            hasplayed = true;
        }
    }
}
