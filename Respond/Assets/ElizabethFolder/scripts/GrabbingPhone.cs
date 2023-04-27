using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;


public class GrabbingPhone : MonoBehaviour
{
    public  XRGrabInteractable phoneGrab;
    public GameObject phoneScreenCanvas;
    
    // Start is called before the first frame update
    void Start()
    {
        phoneGrab = GetComponent<XRGrabInteractable>();
        
    }

    //function for grabbing phone ties with the listener
    public void PhoneGrabbed(XRBaseInteractor interactor)
    {
        
        
            phoneScreenCanvas.gameObject.SetActive(true);
           
    }
    
    // function for phone being dropped, tied to the listener
    public void PhoneDropped(XRBaseInteractor interactor)
    {
        
        
            phoneScreenCanvas.gameObject.SetActive(false);
          
        

    }
}
