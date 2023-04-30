using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotPickupManager : MonoBehaviour
{
    public GameObject[] magicPrefabs;
    private GameObject currentMagic;
    public GameManager gameManager;

    private void Start()
    {
        StartCoroutine(SpawnRandomMagic());
    }

    private void Update()
    {
        if (gameManager.canSpawnRandom)
        {
            StartCoroutine(SpawnRandomMagic());
        }
    }

    public void DestroyMagic()
    {
        Destroy(currentMagic);
   
    }

    IEnumerator SpawnRandomMagic()
    {
        if (transform.childCount < 1)
        {
            int index = Random.Range(0, magicPrefabs.Length);
            currentMagic = Instantiate(magicPrefabs[index], transform.position, Quaternion.identity);
            currentMagic.transform.parent = transform;
        }
        yield return new WaitForSeconds(0.1f);
        gameManager.canSpawnRandom = false;
    }
}
