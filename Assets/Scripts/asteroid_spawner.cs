using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroid_spawner : MonoBehaviour
{
    // Start is called before the first frame update
    //variables based on setup in unity workshop
    public GameObject asteroid;
    public Transform transform;
    public float timeElapsed;
    public float interval;
    public float lifeTime;
    public float rad; // assume ship has radius of around 8
    public float x_rad;
    public float z_rad;
    private int count = 0;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= interval) { //hardcoded times are not ideal; compile time takes forever
            float angle = Random.Range(-Mathf.PI, Mathf.PI);
            rad = 50f;
            x_rad = rad * Mathf.Cos(angle);
            z_rad = rad * Mathf.Sin(angle);
            //Quaternion q = transform.Rotate(new Vector3(0, 1, 0), 180);
            GameObject newAsteroid = Instantiate(asteroid, transform.position + new Vector3(x_rad, 0, z_rad), transform.rotation); //copy an existing object in out scene
            newAsteroid.transform.LookAt(transform.position);
            count++;
            newAsteroid.name = "Asteriod " + count;
            Destroy(newAsteroid, lifeTime); //self destruct pipe clones in five seconds
            timeElapsed = 0;
        }
    }
}
