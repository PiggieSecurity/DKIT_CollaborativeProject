using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Startlevel : MonoBehaviour
{

    public TimeManager TM;
    private void OnTriggerEnter(Collider other)
    {
        TM.Starttimer();
    }
}
