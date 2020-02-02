using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rotation = Vector3.RotateTowards(this.transform.forward, this.transform.right, Mathf.PI/90f, 0f);
        this.transform.rotation = Quaternion.LookRotation(rotation);
    }
}
