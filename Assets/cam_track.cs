using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam_track : MonoBehaviour
{
    public List<Transform> players;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //transform.LookAt(player, Vector3.up);
        int cnt = players.Count;
        float x_sum = 0;
        float z_sum = 0;
        //float y_new = 5;
        //float mag = (players[1].transform.position - players[0].transform.position).magnitude;
        float max_zoom = 0;
        
        if(cnt == 1) {
            transform.position = players[0].transform.position +  new Vector3(0, 10, 0);
        }

        //ignore y
        for (int i = 0; i < cnt; ++i) {
            x_sum += players[i].transform.position.x;
            z_sum += players[i].transform.position.z;
        }

        x_sum /= cnt;
        z_sum /= cnt;
        Vector3 centroid = new Vector3(x_sum, 0, z_sum);

        for (int i = 0; i < cnt; ++i) {
            if ( ((centroid - players[i].transform.position).magnitude) > max_zoom ) {
                max_zoom = (centroid - players[i].transform.position).magnitude;
            }
        }
        /* if((players[1].transform.position - players[0].transform.position).magnitude > 3) {
            y_new = mag * 1.5f; //add f to make double to float
        } */
        transform.position = new Vector3(x_sum, max_zoom * 2.5f, z_sum);
        //transform.position = player.transform.position;
        //transform.position += new Vector3(0,5,0);
        //transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 5, player.transform.position.z + 5);
        /* if ( (player.transform.position - transform.position).magnitude ) {
            transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        } */
    }
}
