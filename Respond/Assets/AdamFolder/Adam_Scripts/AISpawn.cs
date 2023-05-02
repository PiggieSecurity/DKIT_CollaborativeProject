using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace AdamFolder.Adam_Scripts
{
    public class AISpawn : MonoBehaviour
    {
        //in order is the prefab the code will spawn
        //The array of spawn points when they will be inserted into the scene
        //Lastly amount of Prefabs to spawn
        public GameObject RunnerVariant;
        public Transform[] SpawnMovementManager;
        public int numberOfChasers;
        // Delay from each prefab spawning
        public float spawnDelay;

        //Coroutines and IEnumerator load whats within it over time rather than all at once   
        void Start()
        {
            StartCoroutine(SpawnEnemies());
        }

        //IEnumerator 
        IEnumerator SpawnEnemies() 
            
            //Here the code loops through how many "Enemies" have been selected
        {
            for (int i = 0; i < numberOfChasers; i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(spawnDelay);
            }
        }

        
        // "Enemy" will spawn within given array of selected points and 
        void SpawnEnemy()
        {
            int spawnIndex = Random.Range(0, SpawnMovementManager.Length);
            Transform spawnPoint = SpawnMovementManager[spawnIndex];
            
            //Spawns the prefab selected
            Instantiate(RunnerVariant, spawnPoint.position, spawnPoint.rotation);

            NavMeshAgent navMeshAgent = RunnerVariant.GetComponent<NavMeshAgent>();
            navMeshAgent.Warp(spawnPoint.position);
        }
    }
}

/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIspawn : MonoBehaviour
{
    public GameObject Student;
    public Transform[] spawnPoints;
    public int Students;

    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AISpawn());
    }

    IEnumerator AIspawn()
    {
        for (int i = 0; i < Students; i++)
        {
            AIspawn();
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    void AIspawn()
    {
        int spawnIndex = Random.Range(0, spawnPoints.Length); 
        Transform spawnPoint = spawnPoints[spawnIndex];

        GameObject student = Instantiate(enemyPrefab, spawnPoints (1).position, spawnPoints (1).rotation);
        
        GameObject student = Instantiate(enemyPrefab, spawnPoints (2).position, spawnPoints (2).rotation);
       
        GameObject student = Instantiate(enemyPrefab, spawnPoints (3).position, spawnPoints (3).rotation);
        
        GameObject student = Instantiate(enemyPrefab, spawnPoints (4).position, spawnPoints (4).rotation);
       
        GameObject student = Instantiate(enemyPrefab, spawnPoints (5).position, spawnPoints (5).rotation);

        NavMeshAgent navMeshAgent = Student.GetComponent<NavMeshAgent>();
        navMeshAgent.Warp(spawnPoint.position);
    }
}
*/