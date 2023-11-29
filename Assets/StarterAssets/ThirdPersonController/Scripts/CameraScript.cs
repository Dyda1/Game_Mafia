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
    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Linecast(normalPosition.position, frontPosition.position, out hit))
        {
            float tempDistance = Vector3.Distance(normalPosition.position, hit.point);
            mainCamera.transform.localPosition = mainCamera.transform.localPosition + new Vector3(0, 0, +tempDistance);
        }
        else
        {
            mainCamera.transform.localPosition = new Vector3(mainCamera.transform.localPosition.x, mainCamera.transform.localPosition.y, ThirdPersonController._mainCameraPosZ);
        }
    }
}
