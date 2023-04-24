using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// Script is responsible for the smaller models in the scene playing tag possible to...
//implement into NPC script as one cohesive script 
public class Tag : MonoBehaviour
{
    // Start is called before the first frame update
    public enum AIState {
        Chasering,Fleeing,Idle
    }

    private NavMeshAgent _navMeshAgent;
    private GameObject Chaser;
    private GameObject Tagged;
    public AIState currentState = AIState.Idle;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
