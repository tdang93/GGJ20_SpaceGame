using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody playerRigidBody;
    public float speed = 5f;
    private float verticalInput = 0f;
    private float horizontalInput = 0f;
    private Vector3 movement;
    private List<GameObject> nearbyInteractables;
    private GameObject closestInteractable = null;
    public GameObject interactableHighlight;
    // Start is called before the first frame update
    void Start()
    {
        nearbyInteractables = new List<GameObject>();
        movement = Vector3.zero;
        playerRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        this.calculateClosestInteractable();

        verticalInput = Input.GetAxisRaw("Vertical");
        horizontalInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.F)) {
            Debug.Log("F " + this.closestInteractable);
            if (this.closestInteractable) {
                this.closestInteractable.GetComponent<IInteractable>().interact(this.gameObject);
            }
            
        } else if (Input.GetKeyDown(KeyCode.R)) {
            if (this.closestInteractable) {
                this.closestInteractable.GetComponent<IInteractable>().repair(this.gameObject);
            }
        }
        

        //Debug.Log("closest interactable:" + closestInteractable);
    }

    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    void FixedUpdate()
    {
        float x = 10f * horizontalInput;
        float z = 10f * verticalInput;
        movement = new Vector3(x, 0, z);

        transform.LookAt(transform.position + movement);
        movement = movement.normalized * speed;
        
        playerRigidBody.velocity = movement;
    }

    
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Interactable") {
            //Debug.Log("Trigger Enter " + other.transform.name);
            this.nearbyInteractables.Add(other.gameObject);
            //this.calculateClosestInteractable();
        }
    }

    /// OnTriggerExit is called when the Collider other has stopped touching the trigger.
    void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Interactable") {
            //Debug.Log("Collision Exit " + other.transform.name);
            this.nearbyInteractables.Remove(other.gameObject);
            //this.calculateClosestInteractable();
        }
    }

    private void freeMovement() {
        // TODO: make player rotate freely when in space
    }

    private void calculateClosestInteractable() {
        this.closestInteractable = null;

        float smallestDistance = float.MaxValue;
        foreach (GameObject go in this.nearbyInteractables) {
            Vector3 toInteractable = (this.transform.position - go.transform.position);
            float distance = toInteractable.magnitude;
            float dotProduct = Vector3.Dot(toInteractable, -this.transform.forward);
            if (distance < smallestDistance && dotProduct > 0) {
                smallestDistance = distance;
                this.closestInteractable = go;
            }
        }

        this.interactableHighlight.GetComponent<Highlight>().setTarget(this.closestInteractable);
    }
}
