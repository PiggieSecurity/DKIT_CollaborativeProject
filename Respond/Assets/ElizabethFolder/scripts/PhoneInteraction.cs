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
    //[SerializeField] private XRBaseInteractor interactorR ;
    //[SerializeField] private XRBaseInteractor interactorL ;

    [SerializeField] private TMP_Text NumberInput;
    
    // correct emergency numbers 
    private string emergNum = "999";
    private string emergNum2 = "112";
    
    //phone canvases to be assigned
    public GameObject callingScreenCanvas;
    public GameObject phoneScreenCanvas;
    public GameObject onCallCanvas;
    
    // initializing call button , delete button, and end call button
    public Button myCall;
    public Button delInput;
    public Button endCall;
    public Button endCall2;

    // boolean for call button,end call button, delete button to be used to check if it is and isn't pressed
    private bool callButtonIsPressed;
    private bool endCallButtonPressed;
    private bool deleteButtonPressed;
    
    //component for checking if phone is being grabbed 
    public  XRGrabInteractable phoneGrab;

   //boolean for ^ to check if phone is grabbed
    private bool isGrabbed;
    
    //sounds and names 
    public AudioSource[] phoneSound;
    public AudioSource callingSound;
    public AudioSource phoneOperator;
    public AudioSource phoneEnd;

    /*
    public PhoneInteraction(bool phonePickedUp)
    {
        this.phonePickedUp = phonePickedUp;
    }
    */

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
        
        callButtonIsPressed = false;// call button hasnt been pressed 
        
        // setting the grabbed boolean to false at the start and adding a listener for the phone to be grabbed 
        isGrabbed = false;
        
            /*
            // this statemnet properly intializes the phone grab and make sure its value isnt null before adding a listener 
        if (phoneGrab != null)
        {
            phoneGrab.onSelectEntered.AddListener(PhoneGrabbed);
            phoneGrab.onSelectExited.AddListener(PhoneDropped);
            
        }
        */
       
        
    }

    
    void Update()
    {
        
        // check if button is pressed 
        if (Input.GetButtonDown("MyCall"))
        {
            callButtonIsPressed = true;
        }
        // check is end call button pressed
        if (Input.GetButtonDown("EndCall") )
        {
            endCallButtonPressed = true;
        }
        
        // check if delete button is pressed 
        if (Input.GetButtonDown("DeleteInput"))
        {
            deleteButtonPressed = true;
            DeleteText();
        }
        
        
        /*
        // setting screen visibilty for when you pick up and drop phone 
        switch (isGrabbed)
        {
            case true:
                PhoneGrabbed();
                break;
            case false:
              PhoneDropped();
                break;
        }
        */

       
    } 
    
    /*//function for grabbing phone ties with the listener
    public void PhoneGrabbed(XRBaseInteractor interactor)
    {
        if (!isGrabbed)
        {
            phoneScreenCanvas.gameObject.SetActive(true);
            isGrabbed = true;
        }
    }
    
   // function for phone being dropped, tied to the listener
   public void PhoneDropped(XRBaseInteractor interactor)
   {
       if (isGrabbed)
       {
           phoneScreenCanvas.gameObject.SetActive(false);
           isGrabbed = false;
       }

   }*/
    // function for when you press call or delete
    public void EnterNumberPressButton()
    {
        //if statement if the text entered from pressing the buttons is  999 or 112
        if (NumberInput.text == emergNum /*&& callButtonIsPressed==true*/ || NumberInput.text == emergNum2  /*&& callButtonIsPressed==true*/)
        {
            //calls method for calling screen 
            CallingScreen();
            phoneScreenCanvas.SetActive(false);// hide the phone screen  
        }
        
        //if statement if the text entered from pressing the buttons is not 999 or 112
        //if (NumberInput.text != emergNum && callButtonIsPressed==true || NumberInput.text != emergNum2 && callButtonIsPressed==true)
        else
        {
            NumberInput.text = "Incorrect";
            //coroutine to erase the error message
            StartCoroutine(IncorrectErrorMessage());
        }

        IEnumerator IncorrectErrorMessage()
        {
            yield return new WaitForSeconds(3);// 3 second wait
            NumberInput.text = "";//

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
            Invoke("Finished",phoneOperator.clip.length );

        }

        if (endCallButtonPressed==true)
        {
           
          phoneOperator.Stop();
          Finished();// calls this method 
            
        }
       
        // end call button add code for it to stop the call and end all sounds  
    }
// function for when the phone call ends
    public void Finished()
    {
        phoneEnd.Play();
        phoneScreenCanvas.SetActive(false);// hide the phone screen  
        callingScreenCanvas.SetActive(false);// hide call screen 
        onCallCanvas.SetActive(false);// hide on call screen 
    }
    
//make better by deleting individual numbers if there is time 
    public void DeleteText()
    { // erases the number input
        NumberInput.text = ""; 
    }


    
    
}

