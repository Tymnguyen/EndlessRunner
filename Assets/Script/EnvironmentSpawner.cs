using UnityEngine;
using System.Collections.Generic;

public class EnvironmentSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> environmentPrefabs;
    [SerializeField] private Transform player;
    [SerializeField] private float spawnDistance = 20f;
    [SerializeField] private float spawnOffsetZ = 5f; // Độ lệch theo trục z
    [SerializeField] private float sideOffsetX = 5f; // Khoảng cách từ mép đường đến vị trí spawn
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
            // Chọn ngẫu nhiên bên trái hoặc bên phải đường
            float spawnX = (Random.value > 0.5f ? 1 : -1) * sideOffsetX;
            Vector3 spawnPosition = player.position + player.forward * spawnDistance;
            spawnPosition += new Vector3(spawnX, 0, Random.Range(-spawnOffsetZ, spawnOffsetZ)); // Vị trí spawn ở bên trái hoặc phải

            // Kiểm tra khoảng cách với các vật thể khác đã spawn để tránh chồng chéo
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
