using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class SensorScript : MonoBehaviour
{
    //varuiable to be assigned to video boc 
    public VideoPlayer videoWait;
    
    
    public void OnTriggerEnter(Collider other)
    {
       videoWait.Stop();
    }
}

