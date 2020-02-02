using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    private List<GameObject> doorList;
    // Start is called before the first frame update
    void Start()
    {
        this.doorList = new List<GameObject>(GameObject.FindGameObjectsWithTag("Interactable"));
        // foreach (GameObject go in this.doorList) {
        //     if (go.name != "Door") {
        //         this.doorList.Remove(go);
        //     }
        //     Debug.Log("DoorManger::Start() -- " + go.name);
        // }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject findClosestDoor(GameObject target) {
        float smalestDistance = float.MaxValue;
        GameObject closestDoor = null;
        foreach (GameObject door in this.doorList) {
            if (door == target) continue;
            float distance = (door.transform.position - target.transform.position).magnitude;
            if (distance < smalestDistance) {
                smalestDistance = distance;
                closestDoor = door;
            }
        }
        return closestDoor;
    }
}
