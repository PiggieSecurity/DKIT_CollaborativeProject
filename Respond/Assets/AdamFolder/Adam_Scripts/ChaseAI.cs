using UnityEngine;
using UnityEngine.AI;

namespace AdamFolder.Adam_Scripts
{
    public class ChaseAI : MonoBehaviour 
    {
        
        public NavMeshAgent agent;
        public float range; 

        public Transform centrePoint; 

        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
        }
        
        //Navigation aspect of code 
        //AI once it reaches a certain point will set a position with the sphere
        //with the selected range and will set a point to navigate toward it
        void Update()
        {
            if(agent.remainingDistance <= agent.stoppingDistance)
            {
                Vector3 point;
                if (RandomPoint(centrePoint.position, range, out point))
                {
                    agent.SetDestination(point);
                }
            }
        }
        
        //Here a random point is generated and the AI will navigate towards it
        //Once the AI reaches that point to creates a new point
        bool RandomPoint(Vector3 center, float navRange, out Vector3 result)
        {
            Vector3 randomPoint = center + Random.insideUnitSphere * navRange;
            
            //Checks if randomly selected point is actually on the navmesh and if it isnt it will 
            //create a new point
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
            { 
                result = hit.position;
                return true;
            }

            result = Vector3.zero;
            return false;
        }
    }
}