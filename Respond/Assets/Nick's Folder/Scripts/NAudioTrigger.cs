using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NAudioTrigger : MonoBehaviour
{
    public AudioSource SoundtoPlay;

    private void OnTriggerEnter(Collider other)
    {
        SoundtoPlay.Play();
    }
}
