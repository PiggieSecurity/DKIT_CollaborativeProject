using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class elevatorbuttom : MonoBehaviour
{

    [SerializeField] private int level;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("hands"))
        {
            getnumber.level = level;
            SceneManager.LoadScene("SampleScene");
            
        }
       
        

    }
}
