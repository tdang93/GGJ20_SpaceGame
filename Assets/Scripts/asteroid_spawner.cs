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
    private int count = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= interval) { //hardcoded times are not ideal; compile time takes forever
            Vector3 random = new Vector3(Random.Range(10f,12f), 0, Random.Range(-5f,5f));
            GameObject newAsteroid = Instantiate(asteroid, transform.position + random, transform.rotation); //copy an existing object in out scene
            count++;
            newAsteroid.name = "Asteriod " + count;
            Destroy(newAsteroid, lifeTime); //self destruct pipe clones in five seconds
            //Destroy(newAsteroid2, lifeTime);
            timeElapsed = 0;
        }
    }
}
