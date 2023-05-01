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

public class PhoneInteraction : MonoBehaviour
{

    [SerializeField] private TMP_Text NumberInput;
    
    // correct emergency numbers 
    private string emergNum = "999";
    private string emergNum2 = "112";
    
    //phone canvases to be assigned
    public GameObject callingScreenCanvas;
    public GameObject phoneScreenCanvas;
    public GameObject onCallCanvas;
    
    //component for checking if phone is being grabbed 
    public  XRGrabInteractable phoneGrab;

   //boolean for ^ to check if phone is grabbed
    private bool isGrabbed;
    
    //sounds and names 
    public AudioSource[] phoneSound;
    public AudioSource callingSound;
    public AudioSource phoneOperator;
    public AudioSource phoneEnd;
    

    //convert the numbers to string 
    public void Number(int number)
    {
        NumberInput.text += number.ToString();
    }

    void Start()
    { 
        // references for the sound and interactable object 
        AudioSource[] phoneSound= GetComponents<AudioSource>();
        callingSound = phoneSound[0];
        phoneOperator = phoneSound[1];
        phoneEnd = phoneSound[2];

        phoneGrab = GetComponent<XRGrabInteractable>();
        

        phoneScreenCanvas.SetActive(false);// hide the phone screen at the start of the game 
        callingScreenCanvas.SetActive(false);// hide call screen canvas at the start
        onCallCanvas.SetActive(false);// hide oncall screen canvas at the start

        // setting the grabbed boolean to false at the start and adding a listener for the phone to be grabbed 
        isGrabbed = false;
        
    }
    
    // function for when you press call or delete
    public void EnterNumberPressButton()
    {
        //if statement if the text entered from pressing the buttons is  999 or 112
        if (NumberInput.text == emergNum  || NumberInput.text == emergNum2  )
        {
            //calls method for calling screen 
            CallingScreen();
            phoneScreenCanvas.SetActive(false);// hide the phone screen  
        }
        
        //if statement if the text entered from pressing the buttons is not 999 or 112
        
        else
        {
            NumberInput.text = "Incorrect";
            //coroutine to erase the error message
            StartCoroutine(IncorrectErrorMessage());
        }

        IEnumerator IncorrectErrorMessage()
        {
            yield return new WaitForSeconds(3);// 3 second wait
            DeleteText();//delete text function

        }
    }

    // function for calling screen
    private void CallingScreen()
    {
        // shows calling screen 
        callingScreenCanvas.SetActive(true);
        // plays calling sound 
        callingSound.Play();
        //Coroutine that transitions the screens and sound from the calling screen to the on-call screen 
        StartCoroutine(CallingScreenToOnCall());
    }

    IEnumerator CallingScreenToOnCall()
    {
        yield return new WaitForSeconds(7);// leaves everything as is for 7 seconds before switching screens and stopping the calling sound 
        callingScreenCanvas.SetActive(false);
        callingSound.Stop();
      
        OnCallScreen();// summons the ongoing call function for the first time 
        onCallCanvas.SetActive(true);// sets the canvas to visible 
    }

    private void OnCallScreen()
    {
        if (onCallCanvas == true)
        {
            //  greeting and saying that emergency services are on the way to the location
            phoneOperator.Play();

            //invokes the finished method when the phone operator stops speaking
            Invoke("Finished", phoneOperator.clip.length);

        }
    }

// function for when the phone call ends
    public void Finished()
    {
        phoneEnd.Play();
        phoneScreenCanvas.SetActive(false);// hide the phone screen  
        callingScreenCanvas.SetActive(false);// hide call screen 
        onCallCanvas.SetActive(false);// hide on call screen 
        phoneOperator.Stop();
        DeleteText();
    }
    
//make better by deleting individual numbers if there is time 
    public void DeleteText()
    { // erases the number input
        NumberInput.text = ""; 
    }


    
}

