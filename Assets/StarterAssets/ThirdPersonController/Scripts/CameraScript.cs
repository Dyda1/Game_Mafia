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
    public float deltaSpeed = 0.02f;
    float tempDistance;
    Vector3 newPosition;
    RaycastHit hit;
    private float cameraSpeedNow;
    // Start is called before the first frame update
    void Start()
    {
        cameraSpeedNow = cameraSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Linecast(frontPosition.position, normalPosition.position, out hit, 3))
        {
            tempDistance = Vector3.Distance(mainCamera.transform.position, frontPosition.position) - Vector3.Distance(frontPosition.position, hit.point);
            tempDistance += 0.6f;
            //newPosition = mainCamera.transform.position - hit.point;
            newPosition = mainCamera.transform.localPosition + new Vector3(0, 0, tempDistance);

                mainCamera.transform.position = hit.point;
            mainCamera.transform.localPosition += new Vector3(0, 0, 0.6f);

            cameraSpeedNow = cameraSpeed;
            
        }
        else
        {
            /*if (Math.Abs(mainCamera.transform.localPosition.z) < Math.Abs(ThirdPersonController._mainCameraPos.z) && !(Math.Abs(mainCamera.transform.localPosition.z) > Math.Abs(ThirdPersonController._mainCameraPosZ)))
            {
                if (cameraSpeedNow - deltaSpeed * Time.deltaTime > cameraSpeedNow/3)
                {
                    cameraSpeedNow = cameraSpeedNow - deltaSpeed * Time.deltaTime;
                }          
                mainCamera.transform.localPosition = new Vector3(mainCamera.transform.localPosition.x, mainCamera.transform.localPosition.y, mainCamera.transform.localPosition.z - cameraSpeedNow * Time.deltaTime);
            }*/
            mainCamera.transform.localPosition = ThirdPersonController._mainCameraPos;
        }
    }
}
