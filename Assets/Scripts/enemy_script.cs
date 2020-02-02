using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_script : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate() // fixed does make a difference
    {
        GameObject target = null;
        RaycastHit ray;
        if (Physics.Raycast(transform.position, transform.forward, out ray, 10)) { //retrieves collider info thru ray
            target = ray.collider.gameObject; //makes object target
        }

        if(target) {
            if (target.tag == "Player") {
                Debug.Log("enemy sees player");
                Vector3 dist = (target.transform.position - this.transform.position);
                rb.velocity = dist * 2.5f;
                
                //Vector3 objective = (gameObject.transform.forward * dist.magnitude);
                //Vector3 midway = (objective + target.transform.position)/3;
                //transform.LookAt(midway); 
                //rigid deals with the physics of object
            } else { //so far interactables are walls; remove specific case
                transform.Rotate(0, Random.Range(-30f, 30f), 0); //z component is forward

            }
        }
    }

    void OnTriggerEnter(Collider collider) { //collider is set as trigger
        
    }
}
