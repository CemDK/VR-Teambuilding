using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] Camera MenuCamera;
    [SerializeField] MyNetworkManager myNetworkManager;
    [SerializeField] GameObject fadeAnimation;


    public void StartHostClicked() {
        StartCoroutine("StartHost");
    }

    IEnumerator StartHost() {
        MenuCamera.GetComponent<Animation>().Play();
        fadeAnimation.SetActive(true);
        yield return new WaitForSeconds(1);
        myNetworkManager.StartHost();
    }
}
