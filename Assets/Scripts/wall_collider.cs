using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall_collider : MonoBehaviour
{
    private int health = 7;
    public Renderer wall_rend;
    // Start is called before the first frame update
    void Start()
    {
        wall_rend = GetComponent<Renderer>();
        //can't assign outside because component hasn't been declared yet
        //object is declared and assessible once prog nters start()
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision) {
        //Debug.Log("wall " + this.gameObject.name + " collision with " + collision.gameObject.name);
        if(collision.gameObject.tag == "asteroid") {        
            //Debug.Log(this.gameObject.name + " wall collision" + collision.gameObject.name);
            this.health -= 1;
            if (this.health >= 5) {
                wall_rend.material.color = Color.blue;
            } else if (this.health >= 3 ) {
                wall_rend.material.color = Color.gray;
            } else {
                wall_rend.material.color = Color.red;
            }


            if (this.health <= 0) {
                this.gameObject.SetActive(false);
            }
            Destroy(collision.gameObject); //asteroid is a one-time thing
            Debug.LogWarning(this.gameObject.name + "health " + this.health);
        }
    }
}
