using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESCWindow : MonoBehaviour
{
    [SerializeField]
    private GameObject currentWindow;

    private void Update() {
        WindowOff();
    }   

    public void WindowOff()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            currentWindow.SetActive(false);
        }
    }
}
