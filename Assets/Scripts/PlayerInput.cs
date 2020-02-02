using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
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

    private void GetInput() {
        string playerNumber = "";
        if(player == Player.P1) { playerNumber = "1"; }
        else if(player == Player.P2) { playerNumber = "2"; }
        else if(player == Player.P3) { playerNumber = "3"; }

        Horizontal = Input.GetAxis("Horizontal" + playerNumber);
        Vertical = Input.GetAxis("Vertical" + playerNumber);
    }
}
