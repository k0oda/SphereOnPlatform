using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    Collider collider;
    
    float velocityX, velocityY, velocityZ, groundCheckPoint;
    Vector3 movement;

    public Camera camera;

    public float cameraOffsetY = 2;
    public float cameraOffsetZ = -6;
    public float movementSpeed = 10;
    public float jumpForce = 350;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
        groundCheckPoint = collider.bounds.extents.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        // Reset camera position and focus it on player
        camera.transform.position = new Vector3(transform.position.x, transform.position.y + cameraOffsetY, transform.position.z + cameraOffsetZ);
        camera.transform.LookAt(transform);

        velocityX = Input.GetAxis("Horizontal");
        velocityZ = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            velocityY = jumpForce;
        }
        else
        {
            velocityY = 0;
        }

        movement = new Vector3(velocityX * movementSpeed, velocityY, velocityZ * movementSpeed);
        rb.AddForce(movement);
    }

    bool isGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, groundCheckPoint + 0.1f);
    }
}
