using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroid_collision : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject wall;
    public GameObject resourcePrefab;
    private Rigidbody asteroidRigidbody;
    private bool isPulled = false;

    void Start()
    {
        this.transform.parent = GameObject.Find("Asteroids").transform;
        this.asteroidRigidbody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate() {
        this.asteroidRigidbody.velocity = this.transform.forward * 10f;
    }

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.name == "TractorBeam") {
            Debug.Log("Asteroid::OnCollisionEnter()");
            Vector3 position = other.gameObject.GetComponent<TractorBeam>().getPanelPosition();
            this.transform.position = new Vector3(0,0,0); //position
            this.explode();
        } else {
            this.explode();
        }
        
    }

    /// OnTriggerEnter is called when the Collider other enters the trigger.
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "TractorBeam") {
            Debug.Log("Asteroid::OnTriggerEnter() tractorbeam");
            Vector3 position = other.gameObject.GetComponent<TractorBeam>().getPanelPosition();
            this.transform.position = position;
            this.explode();
        }
        if (other.gameObject.tag == "Bullet") {
            this.explode();
        }
    }

    public void explode() {
        GameObject resourceGO = Instantiate(this.resourcePrefab, this.transform.position, this.transform.rotation);
        Destroy(this.gameObject);
    }

    public void pull(GameObject target) {
        this.transform.LookAt(target.transform.position);
        this.asteroidRigidbody.velocity = this.transform.forward;
        this.isPulled = true;
    }
}
