using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraNode : MonoBehaviour
{
    //This is Main Camera in the Scene
    Camera m_MainCamera;

    void Start()
    {
        //This gets the Main Camera from the Scene
        m_MainCamera = Camera.main;
        //This enables Main Camera
        m_MainCamera.enabled = true;
    }

    void Update()
    {

    }
}
