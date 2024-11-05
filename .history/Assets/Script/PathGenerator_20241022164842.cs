using UnityEngine;

public class PathGenerator : MonoBehaviour
{
    public GameObject segmentPrefab;
    private Vector3 nextSpawnPoint;
    private Quaternion nextRotation = Quaternion.identity;
    const int SEGMENTS_BEFORE_TURN = 5;
    const int MAX_SEGMENT_COUNT = 20;
    const int SEGMENT_SQUARE_SIZE = 10;
    void Start()
    {
        for (int i = 0; i < MAX_SEGMENT_COUNT; i++)
        {
            int direction = i % 2 == 0 ? 1 : -1;
            GenerateSegment(i + 1, direction);
        }
    }
    void GenerateSegment(int segmentCount, int direction)
    {
        GameObject newSegment = Instantiate(segmentPrefab, nextSpawnPoint, nextRotation);
        if (segmentCount % SEGMENTS_BEFORE_TURN == 0)
        {
            nextRotation *= Quaternion.Euler(0, 90 * direction, 0); 
        }
        nextSpawnPoint += newSegment.transform.forward * SEGMENT_SQUARE_SIZE; 
    }
}