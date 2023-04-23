using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimatHandOnInput : MonoBehaviour
{
    // Start is called before the first frame update
    public InputActionProperty pinchAnimationAction;
    public Animator handAnimator;
    public InputActionProperty gripAnimationAction;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float triggervalue = pinchAnimationAction.action.ReadValue<float>();
        handAnimator.SetFloat("Trigger", triggervalue);

        float griptrigger = gripAnimationAction.action.ReadValue<float>();
        handAnimator.SetFloat("Grip", griptrigger);
    }
}
