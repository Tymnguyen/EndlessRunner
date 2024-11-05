using UnityEngine;

public class PathGenerator : MonoBehaviour
{
    public GameObject segmentPrefab; 
    private Vector3 nextSpawnPoint;
    private Quaternion nextRotation = Quaternion.identity;
    void Start()
    {
        for (int i = 0; i < 20; i++) // Generate 20 segments as an example
        {
            GenerateSegment();
        }
    }
    void GenerateSegment()
    {
        GameObject newSegment = Instantiate(segmentPrefab, nextSpawnPoint, nextRotation);
        // Update the spawn point for the next segment
        nextSpawnPoint += newSegment.transform.forward; // Move new segment 1 unit forward in the local forward direction
    }
}