using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    Vector3 offset = new Vector3(0, 4, -10);
    private void LateUpdate()
    {
        if (target != null) { }
        transform.position = target.position + offset;
        transform.rotation = target.rotation;
    }
}