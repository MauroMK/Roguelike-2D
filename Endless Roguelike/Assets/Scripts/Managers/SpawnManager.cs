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

    [SerializeField] private float spawnRate = 3.5f; //TODO randomize

    public void Start()
    {
        StartCoroutine(SpawnEnemy(spawnRate));
    }

    //TODO spawn stronger enemies while the game keeps going
    IEnumerator SpawnEnemy(float interval) 
    {
        Vector2 spawnPoint = RandomPointWithinLocations();

        //Wait delay seconds when game starts to spawn a enemy
        yield return new WaitForSeconds(interval);
          
        // Show spawn location for one second
        Object marker = Instantiate(spawnMarker, spawnPoint, Quaternion.identity);
        yield return new WaitForSeconds(1);
        Destroy(marker);
                  
        // Spawn enemy
        GameObject newEnemy = (GameObject) Instantiate(enemyPrefabs[0], spawnPoint, Quaternion.identity);

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
