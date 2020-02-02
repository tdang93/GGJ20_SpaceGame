using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour, IInteractable
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
        Debug.Log("Wall " + this.gameObject + " healed to " + this.health);
    }

    private void OnTriggerEnter(Collider collision) {
        //Debug.Log("wall " + this.gameObject.name + " collision with " + collision.gameObject.name);
        if(collision.gameObject.tag == "asteroid") {        
            //Debug.Log(this.gameObject.name + " wall collision" + collision.gameObject.name);
            // this.health -= 1;
            // if (this.health >= 5) {
            //     wall_rend.material.color = Color.blue;
            // } else if (this.health >= 3 ) {
            //     wall_rend.material.color = Color.gray;
            // } else {
            //     wall_rend.material.color = Color.red;
            // }
            this.changeHealth(-1);


            if (this.health <= 0) {
                this.gameObject.SetActive(false);
            }
            Destroy(collision.gameObject); //asteroid is a one-time thing
            Debug.LogWarning(this.gameObject.name + "health " + this.health);
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
