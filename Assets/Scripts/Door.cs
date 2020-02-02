using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    private bool isOpen = false;
    private Vector3 openPosition;
    private Vector3 closedPosition;
    private SphereCollider sphereCollider;
    // Start is called before the first frame update
    void Start()
    {
        openPosition = new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z);
        closedPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float x = this.transform.position.x;
        float y = this.transform.position.y;
        float z = this.transform.position.z;
        if (this.isOpen) {
            transform.position = openPosition;
        } else {
            transform.position = closedPosition;
        }
    }

    public void interact(GameObject go) {
        Debug.Log("Door::interact() " + go);
        this.isOpen = !this.isOpen;

        GameObject[] interactables = GameObject.FindGameObjectsWithTag("Interactable");
        float smallestDistance = float.MaxValue;
        GameObject closestDoorGO = null;
        foreach (GameObject interactableGO in interactables) {
            if (interactableGO.name == "Door" && interactableGO != this.gameObject) {
                float distance = (this.transform.position - interactableGO.transform.position).magnitude;
                if (distance < smallestDistance) {
                    smallestDistance = distance;
                    closestDoorGO = interactableGO;
                }
                
                Debug.Log("Found a door! ---> " + interactableGO.name);
            }
        }

        if (closestDoorGO) {
            Debug.Log("Found a closest door! " + closestDoorGO.name);
            closestDoorGO.GetComponent<Door>().set(this.isOpen);
        }
    }

    public void repair(GameObject go) {
        Debug.Log("Panel::repair() " + go);
    }

    public void set(bool isOpen) {
        this.isOpen = isOpen;
    }
}
