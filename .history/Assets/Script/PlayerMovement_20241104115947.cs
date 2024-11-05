using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Biến cấu hình
    [SerializeField] private float speed = 5.0f;              // Tốc độ di chuyển về phía trước
    [SerializeField] private float secondsPerTurn = 0.5f;     // Thời gian hoàn thành một lượt rẽ 90 độ
    private float lastTurnTime = 0f;                          // Thời điểm bắt đầu quay lần gần nhất
    private Quaternion targetRotation;                        // Góc quay mục tiêu sau khi rẽ
    private bool isTurning = false;                           // Cờ đánh dấu nếu đang quay

    void Start()
    {
        // Thiết lập giá trị ban đầu của góc quay là góc hiện tại
        targetRotation = transform.rotation;
    }

    void Update()
    {
        // Di chuyển nhân vật về phía trước liên tục
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Kiểm tra nếu thời gian đã trôi qua đủ để quay xong
        if (Time.time - lastTurnTime < secondsPerTurn)
        {
            // Tính số độ cần quay mỗi khung hình
            float maxDegreesDelta = 90f / secondsPerTurn * Time.deltaTime;
            // Thực hiện quay từ từ tới góc mục tiêu
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, maxDegreesDelta);
            return; // Kết thúc logic, không làm thêm gì nữa cho đến khi quay xong
        }
        else
        {
            // Nếu đã quay xong, không cần quay nữa
            isTurning = false;
        }

        // Xử lý đầu vào từ bàn phím (A và D hoặc phím mũi tên)
        float horizontalInput = Input.GetAxisRaw("Horizontal"); // Nhận giá trị -1 (trái), 1 (phải), hoặc 0 (không rẽ)
        
        // Kiểm tra xem có nhận đầu vào để rẽ và hiện không đang rẽ
        if (horizontalInput > 0 && !isTurning)
        {
            StartTurn(90); // Rẽ phải 90 độ
        }
        else if (horizontalInput < 0 && !isTurning)
        {
            StartTurn(-90); // Rẽ trái 90 độ
        }
    }

    // Phương thức xử lý rẽ
    private void StartTurn(float angle)
    {
        // Cập nhật góc quay mục tiêu
        targetRotation *= Quaternion.Euler(0, angle, 0);
        
        // Ghi lại thời điểm bắt đầu quay
        lastTurnTime = Time.time;
        
        // Đặt cờ đánh dấu rằng nhân vật đang quay
        isTurning = true;
    }
}
