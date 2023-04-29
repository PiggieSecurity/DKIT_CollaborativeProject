using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Npc_NavMesh : MonoBehaviour

{
public enum AIState {
    Idle,Roam,Following
}
    private NavMeshAgent _navMeshAgent;
    private GameObject Tagged;
    public AIState currentState = AIState.Idle;

    void Start() {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        Tagged = GameObject.FindWithTag("Tag");
    }

    void Update() {

           switch (currentState) {
      case AIState.Idle:
         // do nothing
         break;
      case AIState.Roam:
         // move to a random location on the NavMesh
         if (!_navMeshAgent.pathPending && _navMeshAgent.remainingDistance < 0.1f) {
            SetRandomDestination();
         }
         break;
        case AIState.Following:
        _navMeshAgent.SetDestination(Tagged.transform.position);
        break; 
           }     
   
 float distanceToPlayer = Vector3.Distance(transform.position, Tagged.transform.position);
   if ((currentState == AIState.Idle || currentState == AIState.Roam) && distanceToPlayer < 5f) {
      {
         currentState = AIState.Following;
      }
      if ((currentState == AIState.Following) && distanceToPlayer > 5f) {
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
