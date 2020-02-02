using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour, IInteractable
{
    public enum PanelTypeEnum { Pilot, Gun, TractorBeam }
    public PanelTypeEnum panelType;
    public GameObject gunGO;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void interact(GameObject go) {
        Debug.Log("Panel::interact() " + go);
        if (this.panelType == PanelTypeEnum.Gun) {
            this.gunGO.GetComponent<Gun>().shoot();
        }
    }

    public void rotate(GameObject go, int direction) {
        this.gunGO.GetComponent<Gun>().rotate(direction);
    }

    public void repair(GameObject go) {
        Debug.Log("Panel::repair() " + go);
    }
}
