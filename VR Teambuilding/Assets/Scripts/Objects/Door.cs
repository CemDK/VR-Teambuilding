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
        }
    }

    public void ChangeDoorState(bool pState) {
        playAudioScript.PlaySoundAtIndex(0);
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
