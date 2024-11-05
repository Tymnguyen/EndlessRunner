using UnityEngine;

public class EnvironmentSpawner : MonoBehaviour
{
    public GameObject[] objectsToSpawn; // Các Prefab cây và đá
    public Transform path; // Đường đi của nhân vật
    public float distanceBetweenObjects = 5f; // Khoảng cách giữa các đối tượng

    void Start()
    {
        PlaceObjectsAlongPath();
    }

    void PlaceObjectsAlongPath()
    {
        Vector3 spawnPositionLeft = path.position - path.right * 3; // Vị trí mép trái của đường
        Vector3 spawnPositionRight = path.position + path.right * 3; // Vị trí mép phải của đường

        for (int i = 0; i < 100; i++) // Điều chỉnh số lượng đối tượng muốn đặt
        {
            // Chọn ngẫu nhiên một Prefab để spawn
            GameObject prefabToSpawn = objectsToSpawn[Random.Range(0, objectsToSpawn.Length)];
            
            // Đặt đối tượng bên trái đường
            Vector3 positionLeft = spawnPositionLeft + i * path.forward * distanceBetweenObjects;
            Instantiate(prefabToSpawn, positionLeft, Quaternion.identity);

            // Đặt đối tượng bên phải đường
            Vector3 positionRight = spawnPositionRight + i * path.forward * distanceBetweenObjects;
            Instantiate(prefabToSpawn, positionRight, Quaternion.identity);
        }
    }
}
