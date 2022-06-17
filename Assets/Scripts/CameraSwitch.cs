using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    private CameraFollow cameraFollowScript;
    private CameraMove cameraMoveScript;

    private bool camViewChanged = false;
    // Start is called before the first frame update
    void Awake()
    {
        cameraFollowScript = Camera.main.GetComponent<CameraFollow>();
        cameraMoveScript = Camera.main.GetComponent<CameraMove>();
        cameraMoveScript.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!camViewChanged)
        {
            if (Input.GetKeyDown(KeyCode.Y))
            {
                camViewChanged = true;
                cameraMoveScript.enabled = true;
                cameraFollowScript.enabled = false;
            }
        } else if (camViewChanged)
        {
            if (Input.GetKeyDown(KeyCode.Y))
            {
                camViewChanged = false;
                cameraMoveScript.enabled = false;
                cameraFollowScript.enabled = true;
            }
        }

    }
}
