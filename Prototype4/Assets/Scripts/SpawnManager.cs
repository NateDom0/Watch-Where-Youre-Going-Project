using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab; // need reference to enemy prefabs
    public GameObject powerupPrefab;
    private float spawnRange = 9.0f;
    public int enemyCount; // keep track of the # of enemies
    public int waveNumber = 1;


    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber); // set to 3
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation); // start with 1 powerup
        //Instantiate(enemyPrefab, new Vector3(0, 0, 6), enemyPrefab.transform.rotation);
        //Instantiate(enemyPrefab, randomPos, enemyPrefab.transform.rotation);
        //Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);

    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for(int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length; // returns the length

        if(enemyCount == 0)
        {
            waveNumber++; // increment waveNumber by 1
            SpawnEnemyWave(waveNumber);
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation); // create another powerup after each wave
        }
    }


    // this function will return a Vector3, randomPos
    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);

        return randomPos;
    }

    // this function(method) instantiates a new powerup and will be called every new wave
    // Function does NOT work: cannot convert from 'UnityEngine.Vector3' to 'UnityEngine.Quaternion'
    // SOLVED: powerupPrefab.transform.ROTATION, not POSITION
    /*
    void SpawnPowerup()
    {
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.position);
    }
    */
}

