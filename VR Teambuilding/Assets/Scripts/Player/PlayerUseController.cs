using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerUseController : NetworkBehaviour {


    public void Use(GameObject pGameObject, int pNumber) {
        Debug.Log(pGameObject.tag);
        CmdUse(pGameObject, pNumber);
    }

    [Command]
    public void CmdUse(GameObject pGameObject, int pNumber) {
        switch (pGameObject.tag) {
            case "Door":
                pGameObject.GetComponent<Door>().Use();
                break;
            case "DoorPuzzle":
                pGameObject.GetComponent<DoorPuzzle>().Solve(pNumber);
                break;
            case "TwoPlayerCube":
                pGameObject.GetComponent<TwoPlayerCube>().Grab();
                break;

            default:
                break;
        }
    }
}
