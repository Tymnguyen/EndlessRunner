using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f; // Adjust speed as needed

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        if(horizontalInput > 0) {
            transform.Rotate(0, 90, 0);
        }
        if(horizontalInput < 0) {
            transform.Rotate(0, -90, 0);
        }
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}