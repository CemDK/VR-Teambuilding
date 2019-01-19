using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MyNetworkManager : NetworkManager{

    void Start(){
        Debug.Log("0. MyNetworkManager Start() called");
    }

    public override void OnStartServer() {
        base.OnStartServer();
        Debug.Log("1. MyNetworkManager OnStartServer() called");
    }

    public override void OnServerConnect(NetworkConnection conn) {
        base.OnServerConnect(conn);
        Debug.Log("2. MyNetworkManager OnServerConnect() called");
        if (this.isActiveAndEnabled) {
            Debug.Log("3. MyNetworkManager this.isActiveAndEnabled true");
        } else {
            Debug.Log("3. MyNetworkManager this.isActiveAndEnabled false");

        }
    }

    public override void OnStartClient(NetworkClient client) {
        base.OnStartClient(client);
        Debug.Log("4. Client started!");
    }

    public override void OnClientConnect(NetworkConnection conn) {
        base.OnClientConnect(conn);
        Debug.Log("5. Client has connected!");
    }
}
