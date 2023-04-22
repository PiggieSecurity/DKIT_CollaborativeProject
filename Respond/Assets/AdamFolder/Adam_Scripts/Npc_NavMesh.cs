using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Npc_NavMesh : MonoBehaviour

{
public enum AIState {
    Idle,Panic,Following
}
    private NavMeshAgent _navMeshAgent;
    private GameObject Victim;
    public AIState currentState = AIState.Idle;

    void Start() {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        Victim = GameObject.FindWithTag("Victim");
    }

    void Update() {

           switch (currentState) {
      case AIState.Idle:
         // do nothing
         break;
      case AIState.Panic:
         // move to a random location on the NavMesh
         if (!_navMeshAgent.pathPending && _navMeshAgent.remainingDistance < 0.1f) {
            SetRandomDestination();
         }
         break;
        case AIState.Following:
        _navMeshAgent.SetDestination(Victim.transform.position);
        break; 
           }     
   
float distanceToPlayer = Vector3.Distance(transform.position, Victim.transform.position);
   if ((currentState == AIState.Idle || currentState == AIState.Panic) && distanceToPlayer < 5f) {
      {
         currentState = AIState.Following;
      }
      if ((currentState == AIState.Following) && distanceToPlayer > 5f) {
         {
            currentState = AIState.Panic;
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
