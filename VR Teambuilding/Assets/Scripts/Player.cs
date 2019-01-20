using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using VRTK;

public class Player : NetworkBehaviour{
    [SerializeField]
    private GameObject head, leftHand, rightHand;
    private GameObject headSet, leftHandController, rightHandController;
    private bool sdkSetupLoaded = false;

    public override void OnStartLocalPlayer() {
        if (isLocalPlayer) {
            Debug.Log("OnStartLocalPlayer()");
            base.OnStartLocalPlayer();
            gameObject.name = "LocalPlayer";
            StartCoroutine("WaitUntilSetupLoaded");
        }
    }

    IEnumerator WaitUntilSetupLoaded() {
        yield return new WaitForSeconds(1f);
        if (VRTK_SDKManager.instance != null && VRTK_SDKManager.instance.loadedSetup != null) {
            headSet = VRTK_SDKManager.instance.loadedSetup.actualHeadset;
            leftHandController = VRTK_SDKManager.instance.loadedSetup.actualLeftController;
            rightHandController = VRTK_SDKManager.instance.loadedSetup.actualRightController;
            sdkSetupLoaded = true;
        } else {
            Debug.Log("SDK Setup not yet sdkSetupLoaded!");
        }
    }

    private void Update(){
        //if (!sdkSetupLoaded) {
        //    if (isLocalPlayer) {
        //        if (VRTK_SDKManager.instance != null && VRTK_SDKManager.instance.loadedSetup != null) {
        //            headSet = VRTK_SDKManager.instance.loadedSetup.actualHeadset;
        //            leftHandController = VRTK_SDKManager.instance.loadedSetup.actualLeftController;
        //            rightHandController = VRTK_SDKManager.instance.loadedSetup.actualRightController;
        //            sdkSetupLoaded = true;
        //        } else {
        //            Debug.Log("SDK Setup not yet sdkSetupLoaded!");
        //        }
        //    }
        //}

        if (isLocalPlayer && sdkSetupLoaded) {
            head.transform.position = headSet.transform.position;
            head.transform.rotation = headSet.transform.rotation;
            leftHand.transform.position = leftHandController.transform.position;
            leftHand.transform.rotation = leftHandController.transform.rotation;
            rightHand.transform.position = rightHandController.transform.position;
            rightHand.transform.rotation = rightHandController.transform.rotation;
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
