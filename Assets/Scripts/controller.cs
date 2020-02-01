using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
{
    private Rigidbody playerRigidBody;
    public float speed;
    private float verticalInput = 0f;
    private float horizontalInput = 0f;
    private Vector3 movement;
    // Start is called before the first frame update
    void Start()
    {
        movement = Vector3.zero;
        playerRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxisRaw("Vertical");
        horizontalInput = Input.GetAxisRaw("Horizontal");
        


    }

    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    void FixedUpdate()
    {
        float x = 10f * horizontalInput;
        float z = 10f * verticalInput;
        movement = new Vector3(x, 0, z);

        transform.LookAt(transform.position + movement);
        movement = movement.normalized * speed;
        
        playerRigidBody.velocity = movement;
    }
}
