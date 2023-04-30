using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBos : MonoBehaviour
{
    [SerializeField] private float initialSpawnRate = 60f;
    [SerializeField] private float maxSpawnRate = 30f;
    [SerializeField] private float spawnRateDecreaseInterval = 40f;
    [SerializeField] private float spawnRateDecreaseAmount = 5f;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform spawnPoint;

    private float currentSpawnRate;

    private void Start()
    {
        currentSpawnRate = initialSpawnRate;
        StartCoroutine(SpawnWithDelay(20f));
    }

    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            AudioManager.instance.PlaySFXAdjusted(6);

            if (Time.time > spawnRateDecreaseInterval && currentSpawnRate > maxSpawnRate)
            {
                currentSpawnRate -= spawnRateDecreaseAmount;
            }

            yield return new WaitForSeconds(currentSpawnRate);
        }
    }

    private IEnumerator SpawnWithDelay(float delaySeconds)
    {
        yield return new WaitForSeconds(delaySeconds);
        StartCoroutine(SpawnRoutine());
    }
}
