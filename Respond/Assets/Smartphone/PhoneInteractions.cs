using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PhoneInteractions : MonoBehaviour
{
    public GameObject UIscreen;
    public TMP_Text phonenumber;
    public TimeManager TM;

    public void CallNumber()
    {
        phonenumber.text = "911";
        TM.CallAmbulance = true;
    }

    public void AddnumbertoDial(int number)
    {
        phonenumber.text = phonenumber.text + number.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            UIscreen.GetComponent<Canvas>().enabled = true;
            CallNumber();
            Debug.Log("called ");
        }
    }
}
