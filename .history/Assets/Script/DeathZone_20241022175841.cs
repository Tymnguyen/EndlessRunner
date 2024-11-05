using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Kiểm tra xem đối tượng va chạm có phải là Player không
        if (other.CompareTag("Player"))
        {
            // Kiểm tra thêm xem nhân vật có rơi xuống một độ cao nhất định (ví dụ, dưới -5) mới hiện thông báo
            if (other.transform.position.y < -5)
            {
                Debug.Log("YOU DIED!!!");
                // Thêm hành động xử lý khác nếu cần
            }
        }
    }
}
