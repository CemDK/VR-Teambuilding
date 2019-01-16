using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using VRTK;

public class DoorButton : MonoBehaviour{

    private VRTK_InteractableObject _linkedObject;
    public GameObject target;

    void Awake(){
        _linkedObject = GetComponent<VRTK_InteractableObject>();
        _linkedObject.InteractableObjectUsed += InteractableObjectUsed;
    }


    private void InteractableObjectUsed(object sender, InteractableObjectEventArgs e){
        Use();
    }

    public void Use() {
        target.GetComponent<Door>().Use();
    }
}
