using UnityEngine;
using UnityEngine.AI;

public class Npc_NavMesh : MonoBehaviour

{
   //States created for Characters
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
         //Switches between the two states 
           switch (currentState) {
              case AIState.Roam:
         // Selects random location on nav mesh
         if (!_navMeshAgent.pathPending && _navMeshAgent.remainingDistance < 0.1f) {
            SetRandomDestination();
         }
         break;
              // Character will try to collide with the Tagged model
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
