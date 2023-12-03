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
    float tempDistance;
    Vector3 newPosition;
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
            tempDistance = Vector3.Distance(mainCamera.transform.position, frontPosition.position) - Vector3.Distance(frontPosition.position, hit.point);
            newPosition = mainCamera.transform.localPosition + new Vector3(0, 0, +tempDistance);
            if (Math.Abs(newPosition.z) < Math.Abs(ThirdPersonController.maxCameraScroll) && Math.Abs(newPosition.z) > 0)
            {
                mainCamera.transform.localPosition = newPosition;
            }
        }
        else
        {
            mainCamera.transform.localPosition = new Vector3(mainCamera.transform.localPosition.x, mainCamera.transform.localPosition.y, ThirdPersonController._mainCameraPosZ);
        }
    }
}
