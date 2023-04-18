using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audiotrigger_once : MonoBehaviour
{
    public AudioSource AudioSource;
    private bool has_played = false;
    private void OnTriggerEnter(Collider other)
    {
        if (!AudioSource.isPlaying && !has_played)
        {
            AudioSource.Play();
            has_played = true;
        }
    }

}
