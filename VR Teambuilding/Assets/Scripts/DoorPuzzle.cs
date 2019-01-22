using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPuzzle : MonoBehaviour
{
    public Door  door0, door1, door2, door3, door4;
    private int state = 0b00000;


    public void Solve(int pButtonNumber) {
        switch (state) {
            case 0b00000:
                if (pButtonNumber == 0) {
                    door0.Open();
                    state = 0b00001;
                } else {
                    CloseDoors();
                }
                break;
            case 0b00001:
                if (pButtonNumber == 1) {
                    door1.Open();
                    state = 0b00011;
                } else {
                    CloseDoors();
                }
                break;
            case 0b00011:
                if (pButtonNumber == 0) {
                    door2.Open();
                    state = 0b00111;
                } else {
                    CloseDoors();
                }
                break;
            case 0b00111:
                if (pButtonNumber == 2) {
                    door3.Open();
                    state = 0b01111;
                } else {
                    CloseDoors();
                }
                break;
            case 0b01111:
                if (pButtonNumber == 1) {
                    door4.Open();
                    state = 0b11111;
                } else {
                    CloseDoors();
                }
                break;
            default:
                CloseDoors();
                break;
        }
    }
    
    private void CloseDoors() {
        door0.Close();
        door1.Close();
        door2.Close();
        door3.Close();
        door4.Close();
        state = 0b000;
    }
}
