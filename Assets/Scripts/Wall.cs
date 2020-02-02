using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour, IInteractable
{
    private float health = 10;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.tag = "Interactable";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void interact(GameObject go) {
        Debug.Log("Wall::interact() " + go);
    }

    public void repair(GameObject go) {
        Debug.Log("Panel::repair() " + go);
        
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Asteroid") {
            this.health -= 1;
            if (this.health <= 0) {
                Destroy(this);
            }
        }
    }
}
