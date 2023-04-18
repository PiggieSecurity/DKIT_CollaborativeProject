using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class follow : MonoBehaviour
{

    public GameObject Mytarget;

    public NavMeshAgent myAgent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Mytarget != null)
        {
            myAgent.destination = Mytarget.transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
      
        Mytarget = other.gameObject;

    }

    private void OnTriggerExit(Collider other)
    {
      
        Mytarget = null;

    }


}
