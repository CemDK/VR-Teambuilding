using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class FloorButton : MonoBehaviour {
    [SerializeField]
    private GameObject target;

    [SerializeField]
    private Animator animator;

    bool enabled = true;


    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("WeightedCube")) {
            animator.SetBool("isPressed", true);
            if (enabled) {
                GameObject.FindGameObjectWithTag("LocalPlayer").GetComponent<Player>().Use(target, 0);
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("WeightedCube")) {
            animator.SetBool("isPressed", false);
            if (enabled) {
                GameObject.FindGameObjectWithTag("LocalPlayer").GetComponent<Player>().Use(target, 0);
            }
        }
    }
}
