using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Transform m_cam;

    private void Start() 
    {
        m_cam = Camera.main.transform;
    }

    private void Update() 
    {
        transform.LookAt(transform.position + m_cam.rotation * Vector3.forward, m_cam.rotation * Vector3.up);
    }
}
