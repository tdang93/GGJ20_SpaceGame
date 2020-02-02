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

    
}
