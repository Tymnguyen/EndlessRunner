using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset = new Vector3(0, 4, -10);

    private void LateUpdate()
    {
        if (target != null)
        {
            // Tính vector offset theo hướng local của target
            Vector3 rotatedOffset = target.TransformDirection(offset);
            Vector3 desiredPosition = target.position + rotatedOffset;

            transform.position = desiredPosition;
            transform.LookAt(target); // Đảm bảo camera luôn nhìn về phía target
        }
    }
}