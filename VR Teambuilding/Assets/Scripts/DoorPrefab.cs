using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(Animator))]
public class DoorPrefab : NetworkBehaviour {

    public GameObject m_MyGameObject;
    public GameObject m_MyInstantiated;
    protected Animator animator;
    private bool open = false;


    void Start() {
        animator = GetComponent<Animator>();
    }

    public void Use() {
        if (this.isOpen()) {
            this.Close();
        } else {
            this.Open();
        }
    }

    public void Open() {
        Debug.Log("Open");
        animator.SetTrigger("Open");
        //animator.Play("DoorOpen");
        open = true;
    }

    public void Close() {
        Debug.Log("Close");
        animator.SetTrigger("Close");
        //animator.Play("DoorClose");
        open = false;
    }


    public bool isOpen() {
        return open;
    }



}
