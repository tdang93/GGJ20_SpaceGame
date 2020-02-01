using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
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
        verticalInput = Input.GetAxisRaw("Vertical");
        horizontalInput = Input.GetAxisRaw("Horizontal");
        

        Debug.Log("closest interactable:" + closestInteractable);
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
            Debug.Log("Trigger Enter " + other.transform.name);
            this.nearbyInteractables.Add(other.gameObject);
            this.calculateClosestInteractable();
        }
    }

    /// OnTriggerExit is called when the Collider other has stopped touching the trigger.
    void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Interactable") {
            Debug.Log("Collision Exit " + other.transform.name);
            this.nearbyInteractables.Remove(other.gameObject);
            this.calculateClosestInteractable();
        }
    }

    private void freeMovement() {
        // TODO: make player rotate freely when in space
    }

    private void calculateClosestInteractable() {
        if (this.nearbyInteractables.Count == 0) {
            this.closestInteractable = null;
        }

        float smallestDistance = float.MaxValue;
        foreach (GameObject go in this.nearbyInteractables) {
            float distance = (go.transform.position - this.transform.position).magnitude;
            if (distance < smallestDistance) {
                smallestDistance = distance;
                closestInteractable = go;
            }
        }

        this.interactableHighlight.GetComponent<HighlightController>().setTarget(closestInteractable);
    }
}
