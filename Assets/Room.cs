using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public List<WallOrDoor> wallsOrDoors;
    public bool isConnected;
    //public Rigidbody rb;
    public Vector3 velocity = Vector3.zero;
    
    // Start is called before the first frame update
    void Start()
    {
        isConnected = true;
        //rb = gameObject.GetComponent<Rigidbody>();
        //rb.useGravity = false;
        //rb.isKinematic = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        int i = 0;
        foreach(WallOrDoor WOD in wallsOrDoors) {
            if (WOD.gameObject.activeSelf) { i++; }
        }
        if(i <= wallsOrDoors.Capacity / 2) { 
            gameObject.transform.parent = null;
            //rb.AddForce(new Vector3(0, 0, -10));
            //gameObject.GetComponent<Rigidbody>().useGravity = true;
            velocity = new Vector3(0, 0, -0.05f);
            transform.Translate(velocity);
            isConnected = false;
        }
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.GetComponent<Player>()) { other.gameObject.GetComponent<Rigidbody>().velocity += velocity; }
    }
}
