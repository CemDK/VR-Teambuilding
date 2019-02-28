using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PressurePlate : NetworkBehaviour {
    [SerializeField]
    private GameObject target;

    [SerializeField]
    private Animator animator;


    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("WeightedCube")) {
            animator.SetBool("isPressed", true);
            if (isServer) {
                target.GetComponent<Door>().Use();
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("WeightedCube")) {
            animator.SetBool("isPressed", false);
            if (isServer) {
                target.GetComponent<Door>().Use();
            }
        }
    }
}
