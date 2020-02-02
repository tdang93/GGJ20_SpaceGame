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

            //Quaternion q = transform.Rotate(new Vector3(0, 1, 0), 180);
            GameObject newAsteroid = Instantiate(asteroid, transform.position + new Vector3(Random.Range(5f,8f), 0, Random.Range(-5f,10f)), transform.rotation); //copy an existing object in out scene
            //GameObject newAsteroid2 = Instantiate(asteroid, transform.position + new Vector3(Random.Range(-8f,-5f), 0, Random.Range(-5f,10f)), transform.rotation);
            count++;
            newAsteroid.name = "Asteriod " + count;
            Destroy(newAsteroid, lifeTime); //self destruct pipe clones in five seconds
            //Destroy(newAsteroid2, lifeTime);
            timeElapsed = 0;
        }
    }
}
