using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WeightedCube : NetworkBehaviour {

    [SerializeField] private Material materialPlayer1;
    [SerializeField] private Material materialPlayer2;

    public void ChangeColor(int player) {
        GameObject cubeBody = gameObject.transform.Find("Body").gameObject;
        if (cubeBody != null) {
            if (player == 1) {
                cubeBody.GetComponent<Renderer>().material = materialPlayer1;
            } else {
                cubeBody.GetComponent<Renderer>().material = materialPlayer2;
            }
        }
        CmdTest();
    }

    [Command]
    public void CmdTest() {
        Debug.Log("TESTCMD");
    }
}
