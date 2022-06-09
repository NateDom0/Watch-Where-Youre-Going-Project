using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab; // need reference to enemy prefabs
    private float spawnRange = 9.0f;

    // Start is called before the first frame update
    void Start()
    {

        //Instantiate(enemyPrefab, new Vector3(0, 0, 6), enemyPrefab.transform.rotation);
        //Instantiate(enemyPrefab, randomPos, enemyPrefab.transform.rotation);
        Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // this function will return a Vector3, randomPos
    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);

        return randomPos;
    }
}
