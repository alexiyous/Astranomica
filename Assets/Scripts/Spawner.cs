using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float spawnRate = 5f;
    [SerializeField] private GameObject[] enemyPrefab;
    [SerializeField] private Transform[] spawnPoint;
    private void Start()
    {
        StartCoroutine(SpawnRoutine());
    }
    private void Update()
    {

    }

    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            //Random Integer generate from 0 until EnemyPrefab length
            int randEnemy = Random.Range(0, enemyPrefab.Length);
            int randSpawn = Random.Range(0, spawnPoint.Length);
            //Prepare prefab at location 
            Instantiate(enemyPrefab[randEnemy], spawnPoint[randSpawn].position, transform.rotation);
            yield return new WaitForSeconds(spawnRate);
        }

    }

}
