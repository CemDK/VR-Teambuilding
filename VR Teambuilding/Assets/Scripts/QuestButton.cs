using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class QuestButton : MonoBehaviour{

    private VRTK_InteractableObject _linkedObject;
    private QuestController questControllerClass;
    public GameObject questController;
    public int buttonNumber;


    void Awake() {
        _linkedObject = GetComponent<VRTK_InteractableObject>();
        _linkedObject.InteractableObjectUsed += InteractableObjectUsed;
        questControllerClass = questController.GetComponent<QuestController>();
    }


    private void InteractableObjectUsed(object sender, InteractableObjectEventArgs e) {
        Debug.Log("Button Used!");
        Use();
    }

    public void Use() {
        questControllerClass.Solve(buttonNumber);
    }
}
