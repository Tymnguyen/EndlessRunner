using UnityEngine;

public class PathGenerator : MonoBehaviour
{
    public GameObject segmentPrefab;
    private Vector3 nextSpawnPoint;
    private Quaternion nextRotation = Quaternion.identity;
    private const int SEGMENTS_BEFORE_TURN = 5;
    private const int MAX_SEGMENT_COUNT = 500;
    private const int SEGMENT_SQUARE_SIZE = 10;
	
    // Tổng góc đã quay mặc định bằng 0
	private int currentTotalRotation = 0;  

    void Start()
    {
        for (int i = 0; i < MAX_SEGMENT_COUNT; i++)
        {
            GenerateSegment(i + 1);
        }
    }
    void GenerateSegment(int segmentCount)
    {
        GameObject newSegment = Instantiate(segmentPrefab, nextSpawnPoint, nextRotation);
        if (segmentCount % SEGMENTS_BEFORE_TURN == 0)
        {
            // Lấy góc quay mới bằng hàm RandomTurnWithConstraint
            int rotationAngle = RandomTurnWithConstraint();
			nextRotation *= Quaternion.Euler(0, rotationAngle, 0);
            currentTotalRotation += ???;
        }
        
        nextSpawnPoint += newSegment.transform.forward * SEGMENT_SQUARE_SIZE;
    }

    int RandomTurnWithConstraint()
    {
        int randomTurn;
        switch (currentTotalRotation)
        {
            case ???: //right max
                randomTurn = Random.Range(???, ???) * 90; //Trái Thẳng
                break;
            case ???: //left max
                randomTurn = Random.Range(???, ???) * 90;   //Phải Thẳng
                break;
            default:
                randomTurn = Random.Range(-1, 2) * 90; //Trái=-1, Phải=1, Thẳng =0
                break;
        }
        return randomTurn;
    }
}