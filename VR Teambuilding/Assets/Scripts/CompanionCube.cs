using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionCube : MonoBehaviour {

    [SerializeField] private Material material;
    // Start is called before the first frame update
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
