using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour{

    private AudioSource audioSource;

    [SerializeField]
    private AudioClip[] audioClips;

    void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySoundAtIndex(int pIndex) {
        audioSource.PlayOneShot(audioClips[pIndex]);
    }
}
