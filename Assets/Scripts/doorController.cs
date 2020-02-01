using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorController : MonoBehaviour, IInteractable
{
    private bool isOpen = false;
    private Vector3 openPosition;
    private Vector3 closedPosition;
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

    public void interact() {
        Debug.Log("Door::interact()");
        this.isOpen = !this.isOpen;
    }
}
