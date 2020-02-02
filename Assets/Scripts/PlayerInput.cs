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

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        GetInput();
    }

    enum ButtonA { A_OFF, A_ON }
    ButtonA buttonA = ButtonA.A_OFF;
    bool A_down = false;

    enum ButtonB { B_OFF, B_ON }
    ButtonB buttonB = ButtonB.B_OFF;
    bool B_down = false;

    enum ButtonX { X_OFF, X_ON }
    ButtonX buttonX = ButtonX.X_OFF;
    bool X_down = false;

    enum ButtonY { Y_OFF, Y_ON }
    ButtonY buttonY = ButtonY.Y_OFF;
    bool Y_down = false;

    private void GetInput() {
        string playerNumber = "";
        if(player == Player.P1) { playerNumber = "1"; }
        else if(player == Player.P2) { playerNumber = "2"; }
        else if(player == Player.P3) { playerNumber = "3"; }

        Horizontal = Input.GetAxis("Horizontal" + playerNumber);
        if(Mathf.Abs(Horizontal) < 0.75f) { Horizontal = 0; }
        Vertical = -Input.GetAxis("Vertical" + playerNumber);
        if (Mathf.Abs(Vertical) < 0.75f) { Vertical = 0; }
        
        A_down = (Input.GetAxis("A" + playerNumber)) == 1;
        //Debug.Log("A_down: " + A_down);
        switch(buttonA){ // Transitions
            case ButtonA.A_OFF:
                if (!A_down) { buttonA = ButtonA.A_OFF; A = false; }
                else if (A_down) { buttonA = ButtonA.A_ON; A = true; Debug.Log("Player" + playerNumber + " A: " + A); }
                break;
            case ButtonA.A_ON:
                if(A_down) { buttonA = ButtonA.A_ON; A = false; }
                else if (!A_down) { buttonA = ButtonA.A_OFF; A = false; }
                break;
            default:
                buttonA = ButtonA.A_OFF;
                break;
        }
        //Debug.Log("Player" + playerNumber + " A: " + A);

        B_down = (Input.GetAxis("B" + playerNumber)) == 1;
        //Debug.Log("B_down: " + B_down);
        switch (buttonB) { // Transitions
            case ButtonB.B_OFF:
                if (!B_down) { buttonB = ButtonB.B_OFF; B = false; }
                else if (B_down) { buttonB = ButtonB.B_ON; B = true; Debug.Log("Player" + playerNumber + " B: " + B); }
                break;
            case ButtonB.B_ON:
                if (B_down) { buttonB = ButtonB.B_ON; B = false; }
                else if (!B_down) { buttonB = ButtonB.B_OFF; B = false; }
                break;
            default:
                buttonB = ButtonB.B_OFF;
                break;
        }
        //Debug.Log("Player" + playerNumber + " B: " + B);

        X_down = (Input.GetAxis("X" + playerNumber)) == 1;
        //Debug.Log("X_down: " + X_down);
        switch (buttonX) { // Transitions
            case ButtonX.X_OFF:
                if (!X_down) { buttonX = ButtonX.X_OFF; X = false; }
                else if (X_down) { buttonX = ButtonX.X_ON; X = true; Debug.Log("Player" + playerNumber + " X: " + X); }
                break;
            case ButtonX.X_ON:
                if (X_down) { buttonX = ButtonX.X_ON; X = false; }
                else if (!X_down) { buttonX = ButtonX.X_OFF; X = false; }
                break;
            default:
                break;
        }
        //Debug.Log("Player" + playerNumber + " X: " + X);

        Y_down = (Input.GetAxis("Y" + playerNumber)) == 1;
        //Debug.Log("Y_down: " + Y_down);
        switch (buttonY) { // Transitions
            case ButtonY.Y_OFF:
                if (!Y_down) { buttonY = ButtonY.Y_OFF; Y = false; }
                else if (Y_down) { buttonY = ButtonY.Y_ON; Y = true; Debug.Log("Player" + playerNumber + " Y: " + Y); }
                break;
            case ButtonY.Y_ON:
                if (Y_down) { buttonY = ButtonY.Y_ON; Y = false; }
                else if (!Y_down) { buttonY = ButtonY.Y_OFF; Y = false; }
                break;
            default:
                buttonY = ButtonY.Y_OFF;
                break;
        }
        //Debug.Log("Player" + playerNumber + " Y: " + Y);
    }
}
