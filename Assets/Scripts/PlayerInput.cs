using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    //[System.Serializable]
    public enum Player { P1, P2, P3 }
    public Player player;

    public float Horizontal;
    public float Vertical;
    public bool A;
    public bool B;
    public bool X;
    public bool Y;

    bool A_down = false;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        GetInput();
    }

    enum ButtonA { A_OFF, A_ON }
    ButtonA buttonA = ButtonA.A_OFF;

    private void GetInput() {
        string playerNumber = "";
        if(player == Player.P1) { playerNumber = "1"; }
        else if(player == Player.P2) { playerNumber = "2"; }
        else if(player == Player.P3) { playerNumber = "3"; }

        Horizontal = Input.GetAxis("Horizontal" + playerNumber);
        if(Mathf.Abs(Horizontal) < 0.75f) { Horizontal = 0; }
        Vertical = -Input.GetAxis("Vertical" + playerNumber);
        if (Mathf.Abs(Vertical) < 0.75f) { Vertical = 0; }

        ///*
        

        //Debug.Log("A: " + Input.GetAxis("A1"));
        
        A_down = (Input.GetAxis("A" + playerNumber)) == 1;

        //Debug.Log("A_down: " + A_down);


        switch(buttonA){ // Transitions
            case ButtonA.A_OFF:
                if (!A_down) { buttonA = ButtonA.A_OFF; A = false; }
                else if (A_down) { buttonA = ButtonA.A_ON; A = true; }
                break;
            case ButtonA.A_ON:
                if(A_down) { buttonA = ButtonA.A_ON; A = false; }
                else if (!A_down) { buttonA = ButtonA.A_OFF; A = false; }
                break;
            default:
                buttonA = ButtonA.A_OFF;
                break;
        }

        Debug.Log("A: " + A);


        /*
        if (!A_down && Input.GetAxis("A" + playerNumber) != 0) {A_down = true; A = true; }
        else if (A_down && Input.GetAxis("A" + playerNumber) != 0) { A_down = true; }
        else if (!A_down && Input.GetAxis("A" + playerNumber) == 0) {A_down = false; }
        else if (A_down && Input.GetAxis("A" + playerNumber) == 0) { A_down = false; }
        */

        //else if(Input.GetAxis("A" + playerNumber) == 0) { A = false; }
        //*/

        //Debug.Log("PlayerInput::GetInput() : playerNumber == " + playerNumber);
    }
}
