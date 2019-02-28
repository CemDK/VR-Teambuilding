using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using VRTK;

public class Handle : NetworkBehaviour{

    [SyncVar]
    private bool grabbed = false;

    private VRTK_InteractableObject _linkedObject;

    void Awake() {
        _linkedObject = gameObject.GetComponent<VRTK_InteractableObject>();
        _linkedObject.InteractableObjectGrabbed += HandleGrabbed;
        _linkedObject.InteractableObjectUngrabbed += HandleUngrabbed;
    }


    private void HandleGrabbed(object sender, InteractableObjectEventArgs e) {
        GameObject.Find("LocalPlayer").GetComponent<AuthorityManager>().CmdAssignAuthority(gameObject.GetComponent<NetworkIdentity>());
        StartCoroutine(WaitForAuthority(true));
    }

    private void HandleUngrabbed(object sender, InteractableObjectEventArgs e) {
        CmdBroadcastState(false);
        GameObject.Find("LocalPlayer").GetComponent<AuthorityManager>().CmdRemoveAuthority(gameObject.GetComponent<NetworkIdentity>());
    }


    IEnumerator WaitForAuthority(bool pState) {
        yield return new WaitUntil(() => hasAuthority);
        CmdBroadcastState(pState);
        yield break;
    }


    [Command]
    private void CmdBroadcastState(bool pState) {
        RpcBroadcastState(pState);
    }

    [ClientRpc]
    private void RpcBroadcastState(bool pState) {
        grabbed = pState;
    }

    [Command]
    public void CmdNewPosition(float xPos, float yPos, float zPos) {
        RpcNewPosition(xPos, yPos, zPos);
    }

    [ClientRpc]
    private void RpcNewPosition(float xPos, float yPos, float zPos) {
        gameObject.transform.position = new Vector3(xPos, yPos, zPos);
    }


    public bool isGrabbed() {
        return grabbed;
    }
}
