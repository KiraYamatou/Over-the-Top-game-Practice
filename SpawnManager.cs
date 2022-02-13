using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    
    public GameObject[] animalPrefabs;
    public GameObject[] animalHPrefabs;
    public GameObject[] animalHRPrefabs;
    private float spawnRangeH = 30.0f;
    private float spawnRangeX = 20.0f;
    private float spawnPosZ = 20.0f;
    private float startDelay = 2.0f;
    private float spawnInterval = 1.5f;

   
    void SpawnRandomAnimal()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    }
    void SpawnHori()
    {
        Vector3 spawnPos = new Vector3(spawnRangeH, 0, Random.Range(-spawnRangeX+25, spawnRangeX));
        int animalIndex = Random.Range(0, animalHPrefabs.Length);

        Instantiate(animalPrefabs[animalIndex], spawnPos, animalHPrefabs[animalIndex].transform.rotation);
    }
    void SpawnHoriR()
    {
        Vector3 spawnPos = new Vector3(-spawnRangeH, 0, Random.Range(-spawnRangeX + 25, spawnRangeX));
        int animalIndex = Random.Range(0, animalHPrefabs.Length);

        Instantiate(animalPrefabs[animalIndex], spawnPos, animalHRPrefabs[animalIndex].transform.rotation);
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
        InvokeRepeating("SpawnHori", startDelay, spawnInterval);
        InvokeRepeating("SpawnHoriR", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

}
