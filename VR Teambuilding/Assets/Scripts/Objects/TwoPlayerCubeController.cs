using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TwoPlayerCubeController : NetworkBehaviour{

    [SerializeField]
    private GameObject blueHandle, yellowHandle, snapPositionBlue, snapPositionYellow;
    private bool yellowGrabbed, blueGrabbed, lastFrameYellowGrabbed, lastFrameBlueGrabbed;
    private AuthorityManager authorityManager;

    private void Start() {
        if (isServer) {
            authorityManager = GameObject.Find("LocalPlayer").GetComponent<AuthorityManager>();
            authorityManager.CmdAssignAuthority(gameObject.GetComponent<NetworkIdentity>());
        }
    }

    private void Update() {
        if (isServer) {
            blueGrabbed = blueHandle.GetComponent<Handle>().isGrabbed();
            yellowGrabbed = yellowHandle.GetComponent<Handle>().isGrabbed();

            if (lastFrameBlueGrabbed && !blueGrabbed) {
                NetworkIdentity networkIdentity = blueHandle.GetComponent<NetworkIdentity>();
                var currentAuthorityOwner = networkIdentity.clientAuthorityOwner;
                if (currentAuthorityOwner != connectionToClient) {
                    if (currentAuthorityOwner != null) {
                        networkIdentity.RemoveClientAuthority(currentAuthorityOwner);
                    }
                    networkIdentity.AssignClientAuthority(connectionToClient);
                }
                blueHandle.transform.position = snapPositionBlue.transform.position;
                float xPos = blueHandle.transform.position.x;
                float yPos = blueHandle.transform.position.y;
                float zPos = blueHandle.transform.position.z;
                blueHandle.GetComponent<Handle>().CmdNewPosition(xPos, yPos, zPos);
            }

            if (lastFrameYellowGrabbed && !yellowGrabbed) {
                NetworkIdentity networkIdentity = blueHandle.GetComponent<NetworkIdentity>();
                var currentAuthorityOwner = networkIdentity.clientAuthorityOwner;
                if (currentAuthorityOwner != connectionToClient) {
                    if (currentAuthorityOwner != null) {
                        networkIdentity.RemoveClientAuthority(currentAuthorityOwner);
                    }
                    networkIdentity.AssignClientAuthority(connectionToClient);
                }
                yellowHandle.transform.position = snapPositionYellow.transform.position;
                float xPos = yellowHandle.transform.position.x;
                float yPos = yellowHandle.transform.position.y;
                float zPos = yellowHandle.transform.position.z;
                yellowHandle.GetComponent<Handle>().CmdNewPosition(xPos, yPos, zPos);
            }


            if (!yellowGrabbed && !blueGrabbed) {
                gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                gameObject.GetComponent<Rigidbody>().useGravity = true;
                blueHandle.transform.position = snapPositionBlue.transform.position;
                float xPos = blueHandle.transform.position.x;
                float yPos = blueHandle.transform.position.y;
                float zPos = blueHandle.transform.position.z;
                blueHandle.GetComponent<Handle>().CmdNewPosition(xPos, yPos, zPos);
                yellowHandle.transform.position = snapPositionYellow.transform.position;
                xPos = yellowHandle.transform.position.x;
                yPos = yellowHandle.transform.position.y;
                zPos = yellowHandle.transform.position.z;
                yellowHandle.GetComponent<Handle>().CmdNewPosition(xPos, yPos, zPos);
            } else if (yellowGrabbed && !blueGrabbed) {
                gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                gameObject.GetComponent<Rigidbody>().useGravity = false;
                gameObject.transform.position = Vector3.MoveTowards(blueHandle.transform.position, yellowHandle.transform.position, 0.6f);
                gameObject.transform.rotation = Quaternion.FromToRotation(Vector3.right, blueHandle.transform.position - yellowHandle.transform.position);
            } else if (!yellowGrabbed && blueGrabbed) {
                gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                gameObject.GetComponent<Rigidbody>().useGravity = false;
                gameObject.transform.position = Vector3.MoveTowards(yellowHandle.transform.position, blueHandle.transform.position, 0.6f);
                gameObject.transform.rotation = Quaternion.FromToRotation(Vector3.left, yellowHandle.transform.position - blueHandle.transform.position);
            } else if (yellowGrabbed && blueGrabbed) {
                gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                gameObject.GetComponent<Rigidbody>().useGravity = false;
                gameObject.transform.position = (blueHandle.transform.position + yellowHandle.transform.position) / 2;
                gameObject.transform.rotation = Quaternion.FromToRotation(Vector3.left, yellowHandle.transform.position - blueHandle.transform.position);
            }
            lastFrameBlueGrabbed = blueGrabbed;
            lastFrameYellowGrabbed = yellowGrabbed;
        }
    }
}
