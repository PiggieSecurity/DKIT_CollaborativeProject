using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject winscreen;
    public GameObject LoseScreen;

    private void Start()
    {
        winscreen.SetActive(false);
        LoseScreen.SetActive(false);
    }
    public void SavedPerson()
    {
        winscreen.SetActive(true);
        winscreen.GetComponent<AudioSource>().Play();
    }


    public void FailedChallenge()
    {
        LoseScreen.SetActive(true);
        LoseScreen.GetComponent<AudioSource>().Play();
    }
}
