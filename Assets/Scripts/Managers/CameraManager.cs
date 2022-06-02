using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Camera pokerCamera;
    public Camera gameCamera;

    private void Start() {
        ChangePokerCam();
    }

    public void ChangeGameCam()
    {
        gameCamera.enabled = true;
        pokerCamera.enabled = false;
    }

    public void ChangePokerCam()
    {
        gameCamera.enabled = false;
        pokerCamera.enabled = true;
    }
}
