using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f; // Adjust speed as needed
    private bool isTurning = false; // Flag to control the turning
    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        if (!isTurning)
        {
            isTurning = true;
            if (horizontalInput > 0)
            {
                transform.Rotate(0, 90, 0);
            }
            if (horizontalInput < 0)
            {
                transform.Rotate(0, -90, 0);
            }
        }
        transform.position += transform.forward * speed * Time.deltaTime;
        if (horizontalInput == 0) isTurning = false;
    }
}