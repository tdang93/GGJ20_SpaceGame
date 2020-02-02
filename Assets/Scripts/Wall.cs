using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour, IInteractable
{
    private float health = 10;
    // Start is called before the first frame update
    void Start()
    {
        this.tag = "Interactable";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void interact() {
        Debug.Log("Wall::interact() " + this.gameObject.name);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Asteroid") {
            this.health -= 1;
            if (this.health <= 0) {
                Destroy(this);
            }
        }
    }
}
