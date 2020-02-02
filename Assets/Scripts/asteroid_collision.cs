using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroid_collision : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject wall;
    public GameObject resourcePrefab;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision) {
        Debug.Log(this.gameObject.name + " collision " + collision.gameObject.name);
        Destroy(this.gameObject);
    }

    /// OnTriggerEnter is called when the Collider other enters the trigger.
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Asteroid::OnTriggerEnter() " + other);
        if (other.gameObject.tag == "Bullet") {
            GameObject resourceGO = Instantiate(this.resourcePrefab, this.transform.position, this.transform.rotation);


            Destroy(this.gameObject);
        }
    }
}
