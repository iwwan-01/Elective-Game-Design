using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private float camSpeed = 10f;
    private float screenSizeThickness = 10f;

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraPosition = transform.position;

        //Up
        if(Input.mousePosition.y >= Screen.height - screenSizeThickness)
        {
            cameraPosition.z += camSpeed * Time.deltaTime;
        }

        //Down
        if (Input.mousePosition.y <= screenSizeThickness)
        {
            cameraPosition.z -= camSpeed * Time.deltaTime;
        }

        //Left
        if (Input.mousePosition.x <= screenSizeThickness)
        {
            cameraPosition.x -= camSpeed * Time.deltaTime;
        }

        //Right
        if (Input.mousePosition.x >= Screen.height - screenSizeThickness)
        {
            cameraPosition.x += camSpeed * Time.deltaTime;
        }

        transform.position = cameraPosition;
    }
}
