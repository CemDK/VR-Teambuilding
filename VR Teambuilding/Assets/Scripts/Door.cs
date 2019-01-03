using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour{

    public GameObject leftDoor;
    public GameObject rightDoor;
    private bool open = false;
    private bool disabled = false;
    private Vector3 left = new Vector3(0, 0, -0.01f);
    private Vector3 right = new Vector3(0, 0, 0.01f);


    public void Open() {
        if (open) {
            StartCoroutine("SlideClosed");
        } else {
            StartCoroutine("SlideOpen");
        }
        this.GetComponent<BoxCollider>().enabled = !this.GetComponent<BoxCollider>().enabled;
        open = !open;
    }

    IEnumerator SlideClosed() {
        for (float f = 0; f < 99; f++) {
            leftDoor.transform.Translate(right);
            rightDoor.transform.Translate(left);
            yield return new WaitForSeconds(.01f);
        }
    }

    IEnumerator SlideOpen() {
        for (float f = 0; f < 99; f++) {
            leftDoor.transform.Translate(left);
            rightDoor.transform.Translate(right);
            yield return new WaitForSeconds(.01f);
        }   
    }



}
