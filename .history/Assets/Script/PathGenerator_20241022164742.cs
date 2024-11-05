using UnityEngine;

public class PathGenerator : MonoBehaviour
{
    public GameObject segmentPrefab; // Assign your 1x1 plane prefab
    private Vector3 nextSpawnPoint;
    private Quaternion nextRotation = Quaternion.identity;
    private int segmentCount = 0;
    private const int SEGMENTS_BEFORE_TURN = 5;

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
        segmentCount++;

        // Check if it's time to turn
        if (segmentCount % SEGMENTS_BEFORE_TURN == 0)
        {
            // Rotate for the next segment
            nextRotation *= Quaternion.Euler(0, 90, 0); // 90 degree turn
        }
        // Update the spawn point for the next segment
        nextSpawnPoint += newSegment.transform.forward; // Move 1 unit forward in the local forward direction
    }
}