using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroid_collision : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject wall;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision) {
        Debug.Log(this.gameObject.name + " collision " + collision.gameObject.name);
        Destroy(this.gameObject);
    }
}
