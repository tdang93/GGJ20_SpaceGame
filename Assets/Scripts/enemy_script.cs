using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_script : MonoBehaviour, IInteractable
{
    // Start is called before the first frame update
    public Rigidbody rb;
    private Rigidbody rb2;

    private int MAX_HEALTH = 10;
    private int health = 10;
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
            //Debug.Log("enemy sees player");
            Vector3 dist = (target.transform.position - this.transform.position);
            rb.velocity = dist * 0.7f;
            //transform.rotation = target.transform.rotation;
            //Vector3 objective = (gameObject.transform.forward * dist.magnitude);
            //Vector3 midway = (objective + target.transform.position)/3;
            //transform.LookAt(midway); 
            //rigid deals with the physics of object
        } else { //so far interactables are walls; remove specific case
            Vector3 rotate = Vector3.RotateTowards(transform.forward, -transform.right, Mathf.PI/90f, 0 ); //z component is forward
            transform.rotation = Quaternion.LookRotation(rotate);
            rb.velocity = new Vector3(0,0,0);
        }
        Debug.Log("target present " + target);

        if (health <= 0) { //eliminate player
            Debug.Log("enemy eliminated");
            this.gameObject.SetActive(false);
            health = 0;
        }
        //Deb
    }

    public void ChangeHealth(int amount) {
        health += amount;
    }

    void OnCollisionEnter(Collision other) { //collider is set as trigger
        rb2 = other.gameObject.GetComponent<Rigidbody>(); //rigidbody of player

        if (other.gameObject.tag == "Player") {
            Debug.Log("enemy tracks player, at dist " + (transform.position - other.gameObject.transform.position).magnitude);
            //if ( (transform.position - collider.gameObject.transform.position).magnitude < 2.7f ) { }
            Debug.Log("enemy attack player: " + other.gameObject.GetComponent<Player>().health);
            rb2.AddForce(30f * transform.forward, ForceMode.Impulse);
            other.gameObject.GetComponent<Player>().ChangeHealth(-1);
        } 
    }

    public void interact(GameObject fighter) {
        ChangeHealth(-1);
        rb.AddForce(30f * fighter.transform.forward, ForceMode.Impulse);
    }

    public void repair(GameObject fighter) {}
        //nothing happens
}
