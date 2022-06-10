using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    private Transform playerPosition;
    private Vector3 cameraOffset;

    [SerializeField]
    [Range(0.01f, 1.0f)]
    private float smoothness = 0.5f;

    void Awake()
    {
        playerPosition = GameObject.Find("Player").GetComponent<Transform>();   
    }
    // Start is called before the first frame update
    void Start()
    {
        cameraOffset = transform.position - playerPosition.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = playerPosition.position + cameraOffset;
        transform.position = Vector3.Slerp(transform.position, newPos, smoothness);
    }
}
