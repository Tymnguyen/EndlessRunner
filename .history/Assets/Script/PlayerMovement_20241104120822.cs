using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;             // Tốc độ di chuyển về phía trước
    [SerializeField] private float turnSpeed = 90.0f;        // Tốc độ xoay trái/phải
    [SerializeField] private float jumpForce = 10.0f;         // Lực nhảy của nhân vật
    
    private bool isGrounded = true;                          // Kiểm tra xem nhân vật có đang ở trên mặt đất không
    private Rigidbody rb;                                    // Đối tượng Rigidbody của nhân vật

    void Start()
    {
        // Thiết lập giá trị ban đầu cho Rigidbody
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Di chuyển nhân vật về phía trước liên tục
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Xử lý đầu vào từ bàn phím (rẽ trái/phải)
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, horizontalInput * turnSpeed * Time.deltaTime);

        // Xử lý nhảy khi nhấn phím "Jump" (mặc định là phím Space)
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;  // Đặt isGrounded thành false khi nhảy
        }
    }

    // Kiểm tra va chạm với mặt đất để cho phép nhảy lại
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;  // Đặt isGrounded thành true khi nhân vật chạm đất
        }
    }
}
