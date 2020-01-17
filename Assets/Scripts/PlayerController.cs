using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    
    float velocityX, velocityY, velocityZ, groundCheckPoint;
    Vector3 movement;

    public Camera camera;

    public float cameraOffsetY = 2;
    public float cameraOffsetZ = -6;
    public float movementSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
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

        movement = new Vector3(velocityX * movementSpeed, velocityY, velocityZ * movementSpeed);
        rb.AddForce(movement);
    }

