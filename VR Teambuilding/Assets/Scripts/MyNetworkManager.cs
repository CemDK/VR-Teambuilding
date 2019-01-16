using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MyNetworkManager : NetworkBehaviour{

    public NetworkManager networkManager;

    // Start is called before the first frame update
    void Start(){
        Debug.Log("Is Server: " + this.isServer);
        Debug.Log("Prefabs: " + networkManager.spawnPrefabs.Count);
        
    }

    public override void OnStartClient() {
        if (this.isServer) {
            NetworkServer.Spawn(networkManager.spawnPrefabs[0]);
            Debug.Log("Door spawned");
        }
    }

    // Update is called once per frame
    void Update(){
        
    }
}
