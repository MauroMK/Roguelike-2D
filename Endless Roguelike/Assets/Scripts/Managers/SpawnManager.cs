using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject spawnMarker;
    
    [SerializeField] private GameObject[] enemyPrefabs;

    [SerializeField] private Transform borderLeft;
    [SerializeField] private Transform borderRight;
    [SerializeField] private Transform borderTop;
    [SerializeField] private Transform borderBottom;

    private float minSpawnRate = 1f; //TODO randomize
    private float maxSpawnRate = 4f;

    private float startDelay = 3f;

    private float destroyMarkerDelay = 1f;

    public void Start()
    {
        // First start with the delay
        StartCoroutine(SpawnEnemy(startDelay));
    }

    //TODO spawn stronger enemies while the game keeps going
    public IEnumerator SpawnEnemy(float interval) 
    {
        // Random float to spawn enemies
        float spawnRate = Random.Range(minSpawnRate, maxSpawnRate);

        // Random position to spawn the marker and the enemy
        Vector2 spawnPoint = RandomPointWithinLocations();

        //Wait delay seconds when game starts to spawn an enemy
        yield return new WaitForSeconds(interval);
          
        // Show spawn location for one second
        Object marker = Instantiate(spawnMarker, spawnPoint, Quaternion.identity);
        yield return new WaitForSeconds(destroyMarkerDelay);
        Destroy(marker);
                  
        // Creating the random enemy list
        int randEnemy = Random.Range(0, enemyPrefabs.Length);

        // Spawn enemy
        GameObject newEnemy = (GameObject) Instantiate(enemyPrefabs[randEnemy], spawnPoint, Quaternion.identity);

        // After the first spawn in the start (with the startDelay, this one uses the random spawnRate to spawn enemies randomly)
        StartCoroutine(SpawnEnemy(spawnRate));
    }

    private Vector2 RandomPointWithinLocations()
    {
        Vector2 random = new Vector2();
        random.x = (int)Random.Range(borderLeft.position.x, borderRight.position.x);
        random.y = (int)Random.Range(borderTop.position.y, borderBottom.position.y);
        return random;
    }
}
