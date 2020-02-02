using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public float Horizontal1;
    public float Vertical1;
    public bool A1;

    public float Horizontal2;
    public float Vertical2;
    public bool A2;

    public float Horizontal3;
    public float Vertical3;
    public bool A3;


    void Start() {
        
    }

    private void Update() {
        //GetInput();
    }

    private void GetInput() {
        Horizontal1 = Input.GetAxis("Horizontal1");
        Vertical1 = Input.GetAxis("Vertical1");
        /*
        if(!A1 && Input.GetAxis("A1") != 0){ A1 = true; }
        else { A1 = false; }
        */

        for(int i = 0; i < 20; i++) {
            A1 = Input.GetButtonDown("joystick 1 button " + i);
        }

        Horizontal2 = Input.GetAxis("Horizontal2");
        Vertical2 = Input.GetAxis("Vertical2");
        A2 = (Input.GetAxis("A2") != 0);

        Horizontal3 = Input.GetAxis("Horizontal3");
        Vertical3 = Input.GetAxis("Vertical3");
        A3 = (Input.GetAxis("A3") != 0);
    }
}
