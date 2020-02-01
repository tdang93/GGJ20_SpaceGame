using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam_track : MonoBehaviour
{
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(player, Vector3.up);
        transform.position = player.transform.position;
        transform.position += new Vector3(0,5,0);
        //transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 5, player.transform.position.z + 5);
        /* if ( (player.transform.position - transform.position).magnitude ) {
            transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        } */
    }
}
