using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class AuthorityManager : NetworkBehaviour {

    [Command]
    public void CmdAssignAuthority(NetworkIdentity networkIdentity) {
        var currentAuthorityOwner = networkIdentity.clientAuthorityOwner;
        if (currentAuthorityOwner != connectionToClient) {
            if (currentAuthorityOwner != null) {
                networkIdentity.RemoveClientAuthority(currentAuthorityOwner);
            }
            networkIdentity.AssignClientAuthority(connectionToClient);
        }
    }

    [Command]
    public void CmdRemoveAuthority(NetworkIdentity networkIdentity) {
        var currentAuthorityOwner = networkIdentity.clientAuthorityOwner;
        if (currentAuthorityOwner == connectionToClient) {
            networkIdentity.RemoveClientAuthority(connectionToClient);
        }
    }
}
