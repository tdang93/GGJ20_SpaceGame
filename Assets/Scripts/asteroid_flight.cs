using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroid_flight : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 velocity;
    private Rigidbody asteroidBody;
    void Start()
    {          
        asteroidBody = GetComponent<Rigidbody>();
        velocity = new Vector3(-1.5f, 0 , 0);   //units per frame, we have 60fps  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate() {
        asteroidBody.velocity = velocity;
    }
}
