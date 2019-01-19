using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(Animator))]
public class Door : NetworkBehaviour {
    [SerializeField]
    protected Animator animator;

    [SyncVar(hook = "ChangeDoorState")]
    private bool open = false;

    public void Use() {
        if (isServer) {
            open = !open;
        } else if(isClient){
            Debug.Log("This shouldn't happen! Door.cs Use() called by Client");
        } else {
            Debug.Log("This shouldn't happen! Door.cs Use() called by ???");
        }
    }

    public void ChangeDoorState(bool pState) {
        animator.SetBool("openDoor", pState);
        animator.SetBool("closeDoor", !pState);
    }
}
