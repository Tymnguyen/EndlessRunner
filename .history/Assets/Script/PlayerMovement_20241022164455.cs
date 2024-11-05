using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f; // Adjust speed as needed
    private bool isTurning = false; // Flag to control the turning
    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");

if(horizontalInput > 0 && !isTurning) {
    transform.Rotate(0, 90, 0);
    isTurning = true;
}
else if(horizontalInput < 0 && !isTurning) {
    transform.Rotate(0, -90, 0);
    isTurning = true;
}
        transform.position += transform.forward * speed * Time.deltaTime;
        if (horizontalInput == 0) isTurning = false;
    }
}