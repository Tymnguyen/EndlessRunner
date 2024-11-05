using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}