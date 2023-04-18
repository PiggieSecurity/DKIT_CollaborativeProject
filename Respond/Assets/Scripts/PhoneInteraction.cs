using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PhoneInteraction : MonoBehaviour
{
    [SerializeField] private Text NumberInput;

    private string emergNum = "999";

    private string emergNum2 = "112";

    // Update is called once per frame
    public void Number(int number)
    {
        NumberInput.text += number.ToString();
    }

    public void Execute()
    {

        if (NumberInput.text == emergNum || NumberInput.text == emergNum2)
        {
            NumberInput.text = "Calling...";
        }
        else
        {

            NumberInput.text = "Incorrect";
        }
    }
}

