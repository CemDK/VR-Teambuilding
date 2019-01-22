using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorButton : MonoBehaviour {
    [SerializeField]
    private GameObject target;

    [SerializeField]
    private Animator animator;


    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("WeightedCube")) {
            animator.SetBool("isPressed", true); 
            GameObject.Find("LocalPlayer").GetComponent<Player>().Use(target, 0);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("WeightedCube")) {
            animator.SetBool("isPressed", false);
            GameObject.Find("LocalPlayer").GetComponent<Player>().Use(target, 0);
        }
    }
}
