using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Stopvideo : MonoBehaviour
{
    public VideoPlayer vp;


    void OnTriggerEnter()
    {
        vp.Stop(); 
    }
}
