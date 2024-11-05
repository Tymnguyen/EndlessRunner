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
            currentTotalRotation += rotationAngle;  // Cập nhật tổng góc quay
        }
        
        nextSpawnPoint += newSegment.transform.forward * SEGMENT_SQUARE_SIZE;
    }

    int RandomTurnWithConstraint()
    {
        int randomTurn;

        // Giới hạn tổng số góc quay, nếu đã quay phải hoặc trái quá 360 độ
        switch (currentTotalRotation)
        {
            case >= 360: // Quay phải quá nhiều
                randomTurn = Random.Range(-1, 1) * 90; // Trái hoặc Thẳng
                break;
            case <= -360: // Quay trái quá nhiều
                randomTurn = Random.Range(0, 2) * 90;  // Phải hoặc Thẳng
                break;
            default:
                randomTurn = Random.Range(-1, 2) * 90; // Trái = -1, Phải = 1, Thẳng = 0
                break;
        }

        return randomTurn;
    }
}
