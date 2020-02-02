using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private const float COOLDOWN = 0.15f;
    private float timer = 0f;
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
        this.timer += Time.deltaTime;
        if (this.timer >= Gun.COOLDOWN) {
            this.timer = 0f;
            Debug.Log("Gun::shoot()");
            Vector3 position = this.transform.position + this.transform.forward * 2f;
            GameObject bullet = Instantiate(this.bulletPrefab, position, this.transform.rotation);
            bullet.tag = "Bullet";
            Vector3 toGun = (bullet.transform.position - this.transform.position);
            Destroy(bullet, 5f);
        }
        
    }

    public void rotate(int dir) {
        Vector3 direction = (dir > 0 ? this.transform.right : -1f * this.transform.right);
        Vector3 rotate = Vector3.RotateTowards(this.transform.forward, direction, Mathf.PI/45f, 0f);
        this.transform.rotation = Quaternion.LookRotation(rotate);
    }
}
