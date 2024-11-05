using UnityEngine;

public class EnvironmentSpawner : MonoBehaviour
{
    public GameObject[] environmentPrefabs; // Các prefab của cây, đá, hoa
    public Transform player; // Đối tượng nhân vật
    public float spawnDistance = 20f; // Khoảng cách giữa các vật thể mới
    public float spawnOffset = 5f; // Độ lệch sang hai bên đường

    private Vector3 lastSpawnPosition;

    private void Start()
    {
        lastSpawnPosition = player.position;
        SpawnEnvironmentObjects();
    }

    private void Update()
    {
        if (Vector3.Distance(player.position, lastSpawnPosition) >= spawnDistance)
        {
            SpawnEnvironmentObjects();
            lastSpawnPosition = player.position;
        }
    }

    void SpawnEnvironmentObjects()
    {
        foreach (var prefab in environmentPrefabs)
        {
            // Tạo vật thể ở bên trái
            Vector3 leftPosition = player.position + Vector3.left * spawnOffset + Vector3.forward * spawnDistance;
            Instantiate(prefab, leftPosition, Quaternion.identity);

            // Tạo vật thể ở bên phải
            Vector3 rightPosition = player.position + Vector3.right * spawnOffset + Vector3.forward * spawnDistance;
            Instantiate(prefab, rightPosition, Quaternion.identity);
        }
    }
}
