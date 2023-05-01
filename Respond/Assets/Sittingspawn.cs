using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Sittingspawn : MonoBehaviour
{
    public GameObject RunnerVariant;
    public Transform[] SpawnMovementManager;
    public int numberOfChasers;

    public float spawnDelay;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnChaser());
    }

    IEnumerator SpawnChaser()
    {
        for (int i = 0; i < numberOfChasers; i++)
        {
            SpawnChaser();
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    void SpawnEnemy()
    {
        int spawnIndex = Random.Range(0, SpawnMovementManager.Length);
        Transform spawnPoint = SpawnMovementManager[spawnIndex];

        GameObject Chaser = Instantiate(RunnerVariant, spawnPoint.position, spawnPoint.rotation);

        NavMeshAgent navMeshAgent = RunnerVariant.GetComponent<NavMeshAgent>();
        navMeshAgent.Warp(spawnPoint.position);
    }
}
