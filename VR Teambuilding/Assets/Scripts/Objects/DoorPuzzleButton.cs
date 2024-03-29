﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class DoorPuzzleButton : MonoBehaviour{
    [SerializeField]
    private GameObject target;
    private VRTK_InteractableObject _linkedObject;
    public int buttonNumber;

    void Awake(){
        _linkedObject = GetComponent<VRTK_InteractableObject>();
        _linkedObject.InteractableObjectUsed += InteractableObjectUsed;
    }

    private void InteractableObjectUsed(object sender, InteractableObjectEventArgs e) {
        GameObject.Find("LocalPlayer").GetComponent<PlayerUseController>().Use(target, buttonNumber);
    }
}
