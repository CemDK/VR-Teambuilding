using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using VRTK;

public class TwoPlayerCube : NetworkBehaviour{

    [SyncVar(hook="OnChangeState")] int state = 0b00;
    private GameObject target;
    private VRTK_InteractableObject _linkedObject;

    void Awake() {
        _linkedObject = GetComponent<VRTK_InteractableObject>();
        _linkedObject.InteractableObjectUsed += InteractableObjectUsed;
    }

    

    public void Grab(){
        state += 1;
    }

    void Update(){
        
    }

    void OnChangeState(int newState) {
        state = newState;
        Debug.Log("State Changed: " + state);
    }

    private void InteractableObjectUsed(object sender, InteractableObjectEventArgs e) {
        GameObject.FindGameObjectWithTag("LocalPlayer").GetComponent<PlayerUseController>().Use(target, 0);
    }
}
