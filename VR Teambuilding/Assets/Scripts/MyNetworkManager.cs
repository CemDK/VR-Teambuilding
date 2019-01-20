using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class MyNetworkManager : NetworkManager{


    public void StartHost(){
        base.StartHost();
        Debug.Log("0. MyNetworkManager StartHost() called");
    }

    public void JoinGame() {
        NetworkManager.singleton.networkAddress = GameObject.Find("InputFieldIPAddress").transform.FindChild("Text").GetComponent<Text>().text;
        NetworkManager.singleton.StartClient();
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
