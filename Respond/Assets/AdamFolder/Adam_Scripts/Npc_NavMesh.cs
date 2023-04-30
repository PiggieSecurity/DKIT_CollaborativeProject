using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Npc_NavMesh : MonoBehaviour

{
public enum AIState {
    Roam,Chase
}
    private NavMeshAgent _navMeshAgent;
    private GameObject Runner;
    public AIState currentState = AIState.Roam;

    void Start() {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        Runner = GameObject.FindWithTag("Tagged");
    }

    void Update() {

           switch (currentState) {
              case AIState.Roam:
         // move to a random location on the NavMesh
         if (!_navMeshAgent.pathPending && _navMeshAgent.remainingDistance < 0.1f) {
            SetRandomDestination();
         }
         break;
        case AIState.Chase:
        _navMeshAgent.SetDestination(Runner.transform.position);
        break; 
           }     
   
 float distanceToPlayer = Vector3.Distance(transform.position, Runner.transform.position);
   if ((currentState == AIState.Chase || currentState == AIState.Roam) && distanceToPlayer < 5f) {
      {
         currentState = AIState.Chase;
      }
      if ((currentState == AIState.Chase) && distanceToPlayer > 5f) {
         {
            currentState = AIState.Roam;
         } 
      }
      
   }
   void SetRandomDestination() {
      var randomDirection = Random.insideUnitSphere * 10f;
      randomDirection += transform.position;
      NavMeshHit hit;
      NavMesh.SamplePosition(randomDirection, out hit, 10f, NavMesh.AllAreas);
      _navMeshAgent.SetDestination(hit.position);
   }

}
    
}
