using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;             // Tốc độ di chuyển về phía trước
    [SerializeField] private float turnSpeed = 90.0f;        // Tốc độ xoay trái/phải

    void Update()
    {
        // Di chuyển nhân vật về phía trước liên tục
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Xử lý đầu vào từ bàn phím (rẽ trái/phải)
        float horizontalInput = Input.GetAxis("Horizontal"); // Nhận giá trị -1 (trái), 1 (phải), hoặc 0 (không rẽ)
        
        // Xoay trái hoặc phải dựa trên đầu vào
        transform.Rotate(Vector3.up, horizontalInput * turnSpeed * Time.deltaTime);
    }
}
