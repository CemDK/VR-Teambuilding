using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using VRTK;

public class Player : NetworkBehaviour {
    [SerializeField]
    private Material BlueDark, Gold;

    [SerializeField]
    private GameObject head, leftHand, rightHand;
    private GameObject headSet, leftHandController, rightHandController;
    private bool sdkSetupLoaded = false;


    public override void OnStartLocalPlayer() {
        base.OnStartLocalPlayer();
        Debug.Log("OnStartLocalPlayer()");
        gameObject.tag = "LocalPlayer";
        gameObject.name = "LocalPlayer";
        StartCoroutine("WaitUntilSetupLoaded");

        //Moving the connecting client VR Setup to <Player 2 Spawn>
        if (!isServer) {
            GameObject SDKManager = GameObject.Find("[VRTK_SDKManager]");
            Transform SpawnPositionTransform = GameObject.Find("Player 2 Spawn").transform;
            SDKManager.transform.position = SpawnPositionTransform.position;
            SDKManager.transform.rotation = SpawnPositionTransform.rotation;
            CmdChangePlayerColor();
            CmdSpawnCubes(2);
        } else {
            CmdSpawnCubes(1);
        }
    }

    [Command]
    public void CmdSpawnCubes(int player) {
        GameObject weightedCubePrefab = NetworkManager.singleton.spawnPrefabs[0];
        foreach (GameObject weightedCubeSpawn in GameObject.FindGameObjectsWithTag("WeightedCubeSpawn")) {
            if (weightedCubeSpawn.name.Equals("Player" + player)) {
                GameObject weightedCube = Instantiate(weightedCubePrefab, weightedCubeSpawn.transform.position, Quaternion.identity);
                NetworkServer.SpawnWithClientAuthority(weightedCube, connectionToClient);
                weightedCube.GetComponent<WeightedCube>().ChangeColor(player);
            }
        }
    }

    [Command]
    void CmdChangePlayerColor() {
        RpcChangePlayerColor();
    }

    [ClientRpc]
    void RpcChangePlayerColor() {
        Debug.Log("RPC!");

        Material newMaterial = (isServer && isLocalPlayer) ? Gold : BlueDark;
        foreach (Renderer ColoredPlayerGameObject in gameObject.GetComponentsInChildren<Renderer>()) {
            if (ColoredPlayerGameObject.tag.Equals("HasPlayerColor")) {
                ColoredPlayerGameObject.material = newMaterial;
            }
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
