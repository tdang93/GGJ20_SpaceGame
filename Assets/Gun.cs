using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void shoot() {
        Debug.Log("Gun::shoot()");

        Vector3 position = this.transform.position - this.transform.forward * 2f;
        GameObject bullet = Instantiate(this.bulletPrefab, position, this.transform.rotation);
        bullet.tag = "Bullet";
        Vector3 toGun = (bullet.transform.position - this.transform.position);
        //bullet.transform.LookAt(toGun);
        Destroy(bullet, 25f);
    }
}
