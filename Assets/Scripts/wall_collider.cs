using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall_collider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision) {
        if(collision.gameObject.tag == "asteroid") {        
            Debug.Log("collision" + collision.gameObject.name);
            Destroy(this.gameObject);
            Destroy(collision.gameObject); //asteroid is a one-time thing
        }
    }
}
