using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] public float J1_H;
    [SerializeField] public float J1_V;

    [SerializeField] public float J2_H;
    [SerializeField] public float J2_V;
    
    [SerializeField] public float J3_H;
    [SerializeField] public float J3_V;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        J1_H = Input.GetAxis("Horizontal1");
        J1_V = Input.GetAxis("Vertical1");

        J2_H = Input.GetAxis("Horizontal2");
        J2_V = Input.GetAxis("Vertical2");

        J3_H = Input.GetAxis("Horizontal3");
        J3_V = Input.GetAxis("Vertical3");
    }
}
