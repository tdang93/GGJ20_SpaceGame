using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    void FixedUpdate()
    {
        this.transform.position += this.transform.forward;
    }

    /// OnTriggerEnter is called when the Collider other enters the trigger.
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Asteroid") {
            Debug.Log("Bullet::OnTriggerEnter() " + other);
        }
    }

    /// OnCollisionEnter is called when this collider/rigidbody has begun
    /// touching another rigidbody/collider.
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Asteroid") {
            Debug.Log("Bullet::OnCollisionEnter() " + other);
        }
    }
}
