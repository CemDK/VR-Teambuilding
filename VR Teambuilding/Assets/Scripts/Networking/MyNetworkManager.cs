using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class MyNetworkManager : NetworkManager{

    private GameObject[] companionCubeSpawns;

    /// <summary>
    /// Exposing the function for use in the Menu_Scene
    /// </summary>
    public void StartHost() {
        base.StartHost();
        Debug.Log("MyNetworkManager: StartHost() called");
    }



    public override void OnStartServer() {
        base.OnStartServer();
        Debug.Log("MyNetworkManager: OnStartServer() called");
        
    }

    public override void OnStartClient(NetworkClient client) {
        base.OnStartClient(client);
        Debug.Log("MyNetworkManager: Client started!");
    }





    //This is called ON THE SERVER! if a client has connected
    public override void OnServerConnect(NetworkConnection conn) {
        base.OnServerConnect(conn);
        Debug.Log("MyNetworkManager: OnServerConnect() called");
        Debug.Log("MyNetworkManager: I am the Server: A client connected with ID: " + conn.connectionId);
        Debug.Log("MyNetworkManager: I am the Server: Host ID: " + conn.hostId);
    }

    //This is called ON THE CLIENT! if the connection to the server is established
    public override void OnClientConnect(NetworkConnection conn) {
        base.OnClientConnect(conn);
        Debug.Log("MyNetworkManager: Client has connected!");
        Debug.Log("MyNetworkManager: I am a Client: Connection ID: " + conn.connectionId);
        Debug.Log("MyNetworkManager: I am a Client: Host ID: " + conn.hostId);
    }


    

    //This is called ON THE SERVER! if a client has disconnected
    //I destroy the player instance and spawned objects corresponding to the clients connection
    public override void OnServerDisconnect(NetworkConnection conn) {
        NetworkServer.DestroyPlayersForConnection(conn);
        Debug.Log("MyNetworkManager: I am the Server: lost connection to " + conn.connectionId + " " + conn.hostId);
    }

    //This is called ON THE CLIENT! if the connection to the server is lost
    public override void OnClientDisconnect(NetworkConnection conn) {
        StopClient();
        Debug.Log("MyNetworkManager: I am a Client: lost connection to Server " + conn.connectionId + " " + conn.hostId);
    }
    

    

    public void JoinGame() {
        NetworkManager.singleton.networkAddress = GameObject.Find("InputFieldIPAddress").transform.Find("Text").GetComponent<Text>().text;
        NetworkManager.singleton.StartClient();
    }
    
}
