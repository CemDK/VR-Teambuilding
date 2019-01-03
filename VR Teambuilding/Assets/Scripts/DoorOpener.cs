using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class DoorOpener : MonoBehaviour{

    private VRTK_InteractableObject _linkedObject;
    public GameObject target;

    void Awake(){
        _linkedObject = GetComponent<VRTK_InteractableObject>();
        _linkedObject.InteractableObjectUsed += InteractableObjectUsed;
    }


    private void InteractableObjectUsed(object sender, InteractableObjectEventArgs e){
        OpenDoor();
    }

    public void OpenDoor() {
        //target.GetComponent<Renderer>().material.color = Random.ColorHSV(1f, 1f);
        target.GetComponent<Door>().Open();
    }
}
