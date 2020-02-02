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


        if (target && target.tag == "Player") {
            Debug.Log("enemy sees player");
            Vector3 dist = (target.transform.position - this.transform.position);
            rb.velocity = dist * 0.7f;
            
            //Vector3 objective = (gameObject.transform.forward * dist.magnitude);
            //Vector3 midway = (objective + target.transform.position)/3;
            //transform.LookAt(midway); 
            //rigid deals with the physics of object
        } else { //so far interactables are walls; remove specific case
            Vector3 rotate = Vector3.RotateTowards(transform.forward, -transform.right, Mathf.PI/10f, 0 ); //z component is forward
            transform.rotation = Quaternion.LookRotation(rotate);
            rb.velocity = new Vector3(0,0,0);
        }
        Debug.Log("target present " + target);
    }

    void OnTriggerEnter(Collider collider) { //collider is set as trigger
        
    }
}
