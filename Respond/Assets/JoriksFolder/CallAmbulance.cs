using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallAmbulance : MonoBehaviour
{
    public TimeManager TM;
    public Canvas EmergencyCalled;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            TM.CallAmbulance = true;
            EmergencyCalled.enabled = true;
            Invoke("Disablescreen", 5f);
        }

    }

    void Disablescreen()
    {
        EmergencyCalled.enabled = false;
    }

}
