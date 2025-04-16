using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonSpawner : MonoBehaviour
{
    public GameObject balloonPrefab;
    public float spawnRate = 1f;

    public float nextSpawnTime;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            SpawnBalloon();
            nextSpawnTime = Time.time + spawnRate;
        }
    }

    void SpawnBalloon()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-8, 8f), -5f, 0f);

        Instantiate(balloonPrefab, spawnPosition, Quaternion.identity);
    }
}
