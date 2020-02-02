using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// OnCollisionStay is called once per frame for every collider/rigidbody
    /// that is touching rigidbody/collider.
    void OnCollisionStay(Collision other)
    {
        // if (other.transform.tag == "Player") {
        //     Debug.Log(this.transform.name + " is touching " + other.transform.name);
        // }
    }
}
