using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class debugani : MonoBehaviour
{
    int i = 0;
    [SerializeField] private Animator myanimationcontroler;
    // Start is called before the first frame update
    void Start()
    {
        
        myanimationcontroler.SetBool("door1", false);
        StartCoroutine(ExampleCoroutine());
       

    }
    IEnumerator ExampleCoroutine()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(4);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        SceneManager.LoadScene("SampleScene");
    }
    // Update is called once per frame
    void Update()
    {
        i++;
        //Debug.Log(i);
        
        if (i > 5000 )
        {
            myanimationcontroler.SetBool("door1", false);
        }
        
        
    }
}
