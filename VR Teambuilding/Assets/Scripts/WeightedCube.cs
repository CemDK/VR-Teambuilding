using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WeightedCube : NetworkBehaviour {

    [SerializeField] private Material material;

    void Start() {
        Renderer renderer = GetComponent<Renderer>();
        foreach (Renderer childRenderer in gameObject.GetComponentsInChildren<Renderer>()) {
            childRenderer.material = material;
        } 
    }

    // Update is called once per frame
    void Update() {
        
    }
}
