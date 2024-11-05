using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float jumpForce = 5.0f; // Lực nhảy
    [SerializeField] private float secondsPerTurn = 0.5f;
    private bool isJumping = false; // Kiểm tra xem nhân vật đang nhảy không
    private Rigidbody rb; // Thêm Rigidbody cho nhân vật để nhảy

    private float lastTurnTime = 0f;
    private Quaternion targetRotation;
    private bool isTurning = false;

    void Start()
    {
        targetRotation = transform.rotation;
        rb = GetComponent<Rigidbody>(); // Gán Rigidbody từ nhân vật
    }

    void Update()
    {
        // Di chuyển về phía trước
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Quay nhân vật
        if (Time.time - lastTurnTime < secondsPerTurn)
        {
            float maxDegreesDelta = 90f / secondsPerTurn * Time.deltaTime;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, maxDegreesDelta);
            return;
        }
        else
        {
            isTurning = false;
        }

        // Kiểm tra nhảy
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping) // Chỉ nhảy khi không đang nhảy
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isJumping = true;
        }

        // Quay trái/phải dựa trên đầu vào bàn phím
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        if (horizontalInput > 0 && !isTurning)
        {
            StartTurn(90);
        }
        else if (horizontalInput < 0 && !isTurning)
        {
            StartTurn(-90);
        }
    }

    private void StartTurn(float angle)
    {
        targetRotation *= Quaternion.Euler(0, angle, 0);
        lastTurnTime = Time.time;
        isTurning = true;
    }

    // Phát hiện chạm đất để reset trạng thái nhảy
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // Đảm bảo `Ground` là tag của Plane hoặc mặt đất
        {
            isJumping = false;
        }
    }
}
