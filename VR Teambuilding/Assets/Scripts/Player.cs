using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using VRTK;

public class Player : NetworkBehaviour{
    [SerializeField]
    private GameObject head, leftHand, rightHand;
    private GameObject leftHandController, rightHandController, headSet;


    public override void OnStartLocalPlayer() {
        base.OnStartLocalPlayer();
        gameObject.name = "LocalPlayer";
        headSet = VRTK_SDKManager.instance.loadedSetup.actualHeadset;
        leftHandController = VRTK_SDKManager.instance.loadedSetup.actualLeftController;
        rightHandController = VRTK_SDKManager.instance.loadedSetup.actualRightController;
    }


    private void Update(){
        if (isLocalPlayer) {
            head.transform.position = headSet.transform.position;
            leftHand.transform.position = leftHandController.transform.position;
            rightHand.transform.position = rightHandController.transform.position;
        }
    }

    public void Use(GameObject pGameObject) {
        CmdUse(pGameObject);
    }

    [Command]
    public void CmdUse(GameObject pGameObject) {
        pGameObject.GetComponent<Door>().Use();
    }
}
