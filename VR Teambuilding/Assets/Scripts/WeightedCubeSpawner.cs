using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WeightedCubeSpawner : NetworkBehaviour {

    //[SerializeField] GameObject companionCubePrefab;
    private GameObject[] companionCubeSpawns;

    public override void OnStartServer() {
        GameObject companionCubePrefab = NetworkManager.singleton.spawnPrefabs[0];
        companionCubeSpawns = GameObject.FindGameObjectsWithTag("WeightedCubeSpawn");
        foreach (GameObject companionCubeSpawn in companionCubeSpawns) {
            GameObject companionCube = Instantiate(companionCubePrefab, companionCubeSpawn.transform.position, Quaternion.identity);
            NetworkServer.Spawn(companionCube);
        }
        
    }
}
