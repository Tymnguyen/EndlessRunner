using UnityEngine;
using System.Collections.Generic;

public class EnvironmentSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> environmentPrefabs;
    [SerializeField] private Transform player;
    [SerializeField] private float spawnDistance = 20f;
    [SerializeField] private float spawnOffset = 5f;
    [SerializeField] private float minSpawnDistanceBetweenObjects = 2f; // khoảng cách tối thiểu giữa các vật thể

    private Vector3 lastSpawnPosition;

    void Start()
    {
        lastSpawnPosition = player.position;
        SpawnEnvironment();
    }

    void Update()
    {
        if (Vector3.Distance(player.position, lastSpawnPosition) > spawnDistance)
        {
            lastSpawnPosition = player.position;
            SpawnEnvironment();
        }
    }

    private void SpawnEnvironment()
    {
        foreach (GameObject prefab in environmentPrefabs)
        {
            Vector3 spawnPosition = player.position + player.forward * spawnDistance;
            spawnPosition += new Vector3(Random.Range(-spawnOffset, spawnOffset), 0, Random.Range(-spawnOffset, spawnOffset));

            // Kiểm tra khoảng cách với các vật thể khác đã spawn
            bool canSpawn = true;
            foreach (Transform child in transform)
            {
                if (Vector3.Distance(spawnPosition, child.position) < minSpawnDistanceBetweenObjects)
                {
                    canSpawn = false;
                    break;
                }
            }

            if (canSpawn)
            {
                GameObject spawnedObject = Instantiate(prefab, spawnPosition, Quaternion.identity, transform);
            }
        }
    }
}
