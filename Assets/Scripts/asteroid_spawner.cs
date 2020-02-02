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

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= interval) { //hardcoded times are not ideal; compile time takes forever
            GameObject newAsteroid = Instantiate(asteroid, transform.position + new Vector3(0, 0, 0), transform.rotation); //copy an existing object in out scene
            Destroy(newAsteroid, lifeTime); //self destruct pipe clones in five seconds
            timeElapsed = 0;
        }
    }
}
