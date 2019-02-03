using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class MenuManager : MonoBehaviour
{
    [SerializeField] Camera MenuCamera;
    [SerializeField] MyNetworkManager myNetworkManager;
    [SerializeField] GameObject fadeAnimation;
    [SerializeField] GameObject postProcessingGameObject;
    PostProcessProfile postProcessProfile;
    float chromaticAberration = 0.1f;

    private void Awake() {
        postProcessProfile = postProcessingGameObject.GetComponent<PostProcessVolume>().profile;
    }


    public void StartHostClicked() {
        StartCoroutine("StartHost");
    }

    IEnumerator StartHost() {
        MenuCamera.GetComponent<Animation>().Play();
        fadeAnimation.SetActive(true);
        for (int i = 0; i < 100; i++) {
            postProcessProfile.GetSetting<ChromaticAberration>().intensity.value += 0.01f;
            yield return new WaitForSeconds(0.011f);
        }
        myNetworkManager.StartHost();
    }

    public void JoinGameClicked() {
        StartCoroutine("JoinGame");
    }

    IEnumerator JoinGame() {
        MenuCamera.GetComponent<Animation>().Play();
        fadeAnimation.SetActive(true);
        for (int i = 0; i < 100; i++) {
            postProcessProfile.GetSetting<ChromaticAberration>().intensity.value += 0.01f;
            yield return new WaitForSeconds(0.011f);
        }
        myNetworkManager.JoinGame();
    }
}
