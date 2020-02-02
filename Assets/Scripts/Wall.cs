using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : WallOrDoor, IInteractable
{
    private int MAX_HEALTH = 7;
    private int health = 7;
    private Renderer wall_rend;
    // Start is called before the first frame update
    void Start()
    {
        wall_rend = GetComponent<Renderer>();
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
        this.changeHealth(1);
    }

    public void rotate(GameObject go, int direction) {
        // Do nothing
    }

    private void OnTriggerEnter(Collider collision) {
        if(collision.gameObject.tag == "asteroid") {        
            this.changeHealth(-1);
            if (this.health <= 0) {
                this.gameObject.SetActive(false);
            }
            Destroy(collision.gameObject); //asteroid is a one-time thing
        }
    }

    private void changeHealth(int amount) {
        this.health += amount;
        if (this.health > this.MAX_HEALTH) this.health = this.MAX_HEALTH;
        if (this.health < 0) this.health = 0;

        if (this.health >= 5) {
            wall_rend.material.color = Color.blue;
        } else if (this.health >= 3 ) {
            wall_rend.material.color = Color.gray;
        } else {
            wall_rend.material.color = Color.red;
        }
    }
}
