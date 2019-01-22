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
        base.OnStartLocalPlayer();
        if (isLocalPlayer) {
            Debug.Log("OnStartLocalPlayer()");
            gameObject.name = "LocalPlayer";
            StartCoroutine("WaitUntilSetupLoaded");
        }
    }

    /// <summary>
    /// Gets the loaded SDK Setup and saves actualHeadset, actualLeftController and actualRightController.
    /// Done in a coroutine, since for me it never loaded in Awake(), Start() or OnStartLocalPlayer()
    /// </summary>
    IEnumerator WaitUntilSetupLoaded() {
        while (!sdkSetupLoaded) {
            if (VRTK_SDKManager.instance != null && VRTK_SDKManager.instance.loadedSetup != null) {
                Debug.Log("Found loaded SDK Setup");
                headSet = VRTK_SDKManager.instance.loadedSetup.actualHeadset;
                leftHandController = VRTK_SDKManager.instance.loadedSetup.actualLeftController;
                rightHandController = VRTK_SDKManager.instance.loadedSetup.actualRightController;
                sdkSetupLoaded = true;
            } else {
                Debug.Log("SDK Setup not yet loaded!");
            }
            yield return null;
        }
    }

    private void Update(){
        if (isLocalPlayer && sdkSetupLoaded) {
            head.transform.position = headSet.transform.position;
            head.transform.rotation = headSet.transform.rotation;
            leftHand.transform.position = leftHandController.transform.position;
            leftHand.transform.rotation = leftHandController.transform.rotation;
            rightHand.transform.position = rightHandController.transform.position;
            rightHand.transform.rotation = rightHandController.transform.rotation;
        }
    }

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
            default:
                break;
        }
    }
}
