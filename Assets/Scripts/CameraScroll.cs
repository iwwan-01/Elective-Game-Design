using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScroll : MonoBehaviour
{
    private Camera cam;
    private float camFOV;
    [SerializeField]
    private float zoomSpeed = 35;

    private float mouseScrollInput;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        camFOV = cam.fieldOfView;
    }

    // Update is called once per frame
    void Update()
    {
        mouseScrollInput = Input.GetAxis("Mouse ScrollWheel");

        camFOV -= mouseScrollInput * zoomSpeed;
        // Locks the field of view value between the values of 30 and 60
        camFOV = Mathf.Clamp(camFOV, 30, 60);

        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, camFOV, zoomSpeed);
    }
}
