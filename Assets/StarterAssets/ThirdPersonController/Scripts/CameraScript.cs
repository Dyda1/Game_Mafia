using StarterAssets;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject mainCamera;
    public Transform normalPosition;
    public Transform frontPosition;
    public float cameraSpeed = 12.0f;
    public float deltaSpeedX = 0.001f;
    public float deltaSpeedZ = 0.03f;
    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Linecast(frontPosition.position, normalPosition.position, out hit, 3))
        {
            mainCamera.transform.position = hit.point;
            mainCamera.transform.localPosition += new Vector3(0, 0, 0.6f);
        }
        else
        {
            if (ThirdPersonController._mainCameraPos.z < mainCamera.transform.localPosition.z - deltaSpeedZ)
            {
                mainCamera.transform.localPosition += new Vector3(0, 0, -deltaSpeedZ);
            }
            if (ThirdPersonController._mainCameraPos.x > mainCamera.transform.localPosition.x + deltaSpeedX)
            {
                mainCamera.transform.localPosition += new Vector3(deltaSpeedX, 0, 0);
            }
        }
    }
}
