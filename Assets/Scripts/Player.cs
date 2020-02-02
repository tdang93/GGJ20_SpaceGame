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
    private List<GameObject> nearbyInteractables = new List<GameObject>();
    private GameObject closestInteractable = null;
    public GameObject interactableHighlight;
    
    public PlayerInput playerInput;

    /// Awake is called when the script instance is being loaded.
    void Awake()
    {
        
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
        this.movement = Vector3.zero;
        this.playerRigidBody = GetComponent<Rigidbody>();
        this.playerInput = this.GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        this.calculateClosestInteractable();

        float keyboard_verticalInput = Input.GetAxisRaw("Vertical");
        float keyboard_horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = playerInput.Vertical + keyboard_verticalInput;
        horizontalInput = playerInput.Horizontal + keyboard_horizontalInput;

        if (Input.GetKeyDown(KeyCode.F) || playerInput.A) {
            if (this.closestInteractable) {
                this.closestInteractable.GetComponent<IInteractable>().interact(this.gameObject);
            }
            
        }   
        else if (Input.GetKey(KeyCode.G) || playerInput.A_held) {
            if (this.closestInteractable) {
                if(this.closestInteractable.GetComponent<Panel>()) {
                    Panel p = this.closestInteractable.GetComponent<Panel>();
                    if(p.panelType == Panel.PanelTypeEnum.Gun || p.panelType == Panel.PanelTypeEnum.TractorBeam) {
                        p.interact(this.gameObject);
                    }
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.R) || playerInput.B) {
            if (this.closestInteractable) {
                this.closestInteractable.GetComponent<IInteractable>().repair(this.gameObject);
            }
        }
        
        if (Input.GetKey(KeyCode.Q) || playerInput.LT > 0) {
            if (this.closestInteractable) {
                IInteractable II = this.closestInteractable.GetComponent<IInteractable>();
                if(playerInput.LT > 0) { II.rotate(this.gameObject, (int) -playerInput.LT); }
                else { II.rotate(this.gameObject, -1); }
            }
        } else if (Input.GetKey(KeyCode.E) || playerInput.RT > 0) {
            if (this.closestInteractable) {
                IInteractable II = this.closestInteractable.GetComponent<IInteractable>();
                if(playerInput.RT > 0) { II.rotate(this.gameObject, (int) playerInput.RT); }
                else { II.rotate(this.gameObject, 1); }
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
            GameObject go = other.gameObject;
            this.nearbyInteractables.Add(go);
        }
    }

    /// OnTriggerExit is called when the Collider other has stopped touching the trigger.
    void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Interactable") {
            this.nearbyInteractables.Remove(other.gameObject);
        }
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
