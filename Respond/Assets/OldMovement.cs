using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OldMovement : MonoBehaviour
{

    //Interface for unity input
    [SerializeField] private Transform FirstPosition;

    private NavMeshAgent navmeshAgent;

    
    //Upon start of game
    private void Awake()
    {
        navmeshAgent = GetComponent<NavMeshAgent>();
    }
//AI will travel to given point rather than randomly navigate around the scene
    private void Update() {
        navmeshAgent.destination = FirstPosition.position;
    }
}

