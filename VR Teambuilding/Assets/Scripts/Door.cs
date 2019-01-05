using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour{

    public GameObject leftDoor;
    public GameObject rightDoor;
    private bool open = false;
    private Vector3 left = new Vector3(0, 0, -0.01f);
    private Vector3 right = new Vector3(0, 0, 0.01f);


    public void Use() {
        if (open) {
            StartCoroutine("SlideClosed");
        } else {
            StartCoroutine("SlideOpen");
        }
        open = !open;
    }

    public void Open() {
        if (!open) {
            StartCoroutine("SlideOpen");
            open = true;
        }
    }

    public void Close() {
        if (open) {
            StartCoroutine("SlideClosed");
            open = false;
        }
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

    public bool isOpen() {
        return open;
    }



}
