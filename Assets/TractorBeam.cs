using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TractorBeam : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject panelGO;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void shoot() {
        Debug.Log("Gun::shoot()");

        RaycastHit hitInfo;
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        if ( Physics.Raycast(this.transform.position, forward, out hitInfo, 10f) && hitInfo.collider.gameObject.tag == "asteroid") {
            Debug.DrawRay(transform.position, forward * hitInfo.distance, Color.red);
            hitInfo.collider.gameObject.GetComponent<asteroid_collision>().pull(this.gameObject);
        } else {
            Debug.DrawRay(transform.position, forward * 1000, Color.white);
        }
        
    }

    public void rotate(int dir) {
        Vector3 direction = (dir > 0 ? this.transform.right : -1f * this.transform.right);
        Vector3 rotate = Vector3.RotateTowards(this.transform.forward, direction, Mathf.PI/45f, 0f);
        this.transform.rotation = Quaternion.LookRotation(rotate);
    }

    public Vector3 getPanelPosition() {
        return this.panelGO.GetComponent<Panel>().getRoomPosition();
    }
}
