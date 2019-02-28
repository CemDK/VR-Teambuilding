using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using VRTK;

public class WeightedCube : NetworkBehaviour {

    private VRTK_InteractableObject _linkedObject;

    void Awake() {
        _linkedObject = gameObject.GetComponent<VRTK_InteractableObject>();
        _linkedObject.InteractableObjectGrabbed += HandleGrabbed;
        _linkedObject.InteractableObjectUngrabbed += HandleUngrabbed;
    }


    private void HandleGrabbed(object sender, InteractableObjectEventArgs e) {
        GameObject.Find("LocalPlayer").GetComponent<AuthorityManager>().CmdAssignAuthority(gameObject.GetComponent<NetworkIdentity>());
    }

    private void HandleUngrabbed(object sender, InteractableObjectEventArgs e) {
        GameObject.Find("LocalPlayer").GetComponent<AuthorityManager>().CmdRemoveAuthority(gameObject.GetComponent<NetworkIdentity>());
    }
}
