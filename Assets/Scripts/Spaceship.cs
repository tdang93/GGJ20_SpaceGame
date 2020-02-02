using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    List<Transform> rooms;
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
        // Move each child room
        // for (int i = 0; i < this.transform.childCount; i++) {
        //     Transform child = this.transform.GetChild(i);
        //     child.position += new Vector3(1, 0, 0) * Time.deltaTime;
        // }
    }
}
