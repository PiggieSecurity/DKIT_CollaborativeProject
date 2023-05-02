using UnityEngine;
using UnityEngine.AI;

namespace AdamFolder.Adam_Scripts
{
    public class OldMovement : MonoBehaviour
    {

        //Interface for unity input once object within scene is placed within AI will Navigate toward it 
        [SerializeField] private Transform FirstPosition;

        private NavMeshAgent navmeshAgent;

    
        //Upon start of game
        private void Awake()
        {
            navmeshAgent = GetComponent<NavMeshAgent>();
        }
//AI will travel to given point rather than randomly navigate around the scene
//but is still under the constraints of the nav-mesh
        private void Update() {
            navmeshAgent.destination = FirstPosition.position;
        }
    }
}

