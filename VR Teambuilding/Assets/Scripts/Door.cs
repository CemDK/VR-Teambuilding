using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(Animator))]
public class Door : NetworkBehaviour {
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private PlayAudio playAudioScript;

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
        int clip = pState ? 1 : 0;
        playAudioScript.PlaySoundAtIndex(clip);
        animator.SetBool("openDoor", pState);
        animator.SetBool("closeDoor", !pState);
    }

    public void Open() {
        if (!open) {
            open = true;
        }
    }

    public void Close() {
        if (open) {
            open = false;
        }
    }
}
