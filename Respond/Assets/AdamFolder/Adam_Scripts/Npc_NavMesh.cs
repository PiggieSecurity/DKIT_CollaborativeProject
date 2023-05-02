using UnityEngine;
using UnityEngine.AI;

namespace AdamFolder.Adam_Scripts
{
   public class Npc_NavMesh : MonoBehaviour

   {
      //Defines the states for Characters being either Roam or Chase
      public enum AIState {
         Roam,Chase
      }
      
      private NavMeshAgent _navMeshAgent;
      private GameObject Runner;
      
      //State the AI will start the scene set as 
      public AIState currentState = AIState.Roam;

      
      //Runner Object will naviagte towards anything with the Tag "Tagged"
      void Start() {
         _navMeshAgent = GetComponent<NavMeshAgent>();
         Runner = GameObject.FindWithTag("Tagged");
      }

      
      void Update() {
         //Switch allows for the AI to change state
         //from either roaming or chasing
         switch (currentState) {
            case AIState.Roam:
               //While in Roam the AI will naviagte randomly within the Navmesh 
               if (!_navMeshAgent.pathPending && _navMeshAgent.remainingDistance < 0.1f) {
                  SetRandomDestination();
               }
               break;
            // Character will try to collide with the Tagged model
            case AIState.Chase:
               _navMeshAgent.SetDestination(Runner.transform.position);
               break; 
         }     
   
         //Manages the distance from curent object to the Chased AI/Object
         float distanceToPlayer = Vector3.Distance(transform.position, Runner.transform.position);
         if ((currentState == AIState.Chase || currentState == AIState.Roam) && distanceToPlayer < 5f) {
            {
               currentState = AIState.Chase;
            }
            //State changes based on proximity to the Chased AI/Object
            if ((currentState == AIState.Chase) && distanceToPlayer > 5f) {
               {
                  currentState = AIState.Roam;
               } 
            }
         }
         
         //Takes the AI's current position and updates its where it will navigate
         //to next within its "range"
         void SetRandomDestination() {
            var randomDirection = Random.insideUnitSphere * 10f;
            randomDirection += transform.position;
            NavMeshHit hit;
            NavMesh.SamplePosition(randomDirection, out hit, 10f, NavMesh.AllAreas);
            _navMeshAgent.SetDestination(hit.position);
         }
      }
   }
}
