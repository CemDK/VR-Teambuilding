using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WeightedCubeSpawner : NetworkBehaviour {

    //[SerializeField] GameObject weightedCubePrefab;
    private GameObject[] weightedCubeSpawns;
    
    public void Spawn(NetworkConnection networkConnection, int player) {
        GameObject weightedCubePrefab = NetworkManager.singleton.spawnPrefabs[0];
        weightedCubeSpawns = GameObject.FindGameObjectsWithTag("WeightedCubeSpawn");
        foreach (GameObject weightedCubeSpawn in weightedCubeSpawns) {
            if (weightedCubeSpawn.name.Equals("Player" + player)){
                weightedCubePrefab.GetComponent<WeightedCube>().ChangeColor(player);
                GameObject weightedCube = Instantiate(weightedCubePrefab, weightedCubeSpawn.transform.position, Quaternion.identity);
                NetworkServer.SpawnWithClientAuthority(weightedCube, networkConnection);
            }
        }
        
    }
}
