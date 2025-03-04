using UnityEngine;

public class PathGenerator : MonoBehaviour
{
    public GameObject segmentPrefab;
    private Vector3 nextSpawnPoint;
    private Quaternion nextRotation = Quaternion.identity;
    const int SEGMENTS_BEFORE_TURN = 5;
    const int MAX_SEGMENT_COUNT = 100;
    const int SEGMENT_SQUARE_SIZE = 10;
    void Start()
    {
        for (int i = 0; i < MAX_SEGMENT_COUNT; i++) // Generate 20 segments as an example
        {
            int direction = Random.Range(-1, 2);
            GenerateSegment(i + 1, direction);//Loại bỏ trường hợp 0 chia hết cho 5. Ô đầu tiên
        }
    }
    void GenerateSegment(int segmentCount, int direction)
    {
        GameObject newSegment = Instantiate(segmentPrefab, nextSpawnPoint, nextRotation);
        if (segmentCount % SEGMENTS_BEFORE_TURN == 0)
        {
            // Rotate for the next segment
            nextRotation *= Quaternion.Euler(0, 90 * direction, 0); // 90 degree turn
        }
        // Update the spawn point for the next segment
        nextSpawnPoint += newSegment.transform.forward * SEGMENT_SQUARE_SIZE; // Move new segment 5 unit forward in the local forward direction
    }
}