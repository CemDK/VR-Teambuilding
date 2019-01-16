using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using VRTK;

public class PlayerMover : NetworkBehaviour{
    [SerializeField]
    private GameObject head, leftHand, rightHand;
    private GameObject leftHandController, rightHandController, headSet;


    public override void OnStartLocalPlayer() {
        leftHandController = VRTK_SDKManager.instance.loadedSetup.actualLeftController;
        rightHandController = VRTK_SDKManager.instance.loadedSetup.actualRightController;
        headSet = VRTK_SDKManager.instance.loadedSetup.actualHeadset;
    }

    // Update is called once per frame
    private void Update(){
        if (isLocalPlayer) {
            leftHand.transform.position = leftHandController.transform.position;
            rightHand.transform.position = rightHandController.transform.position;
            head.transform.position = headSet.transform.position;
        }
    }
}
