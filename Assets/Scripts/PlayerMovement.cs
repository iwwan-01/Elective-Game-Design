using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class PlayerMovement : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    [SerializeField]
    private float rotateSpeedMovement = 0.1f;
    private float rotateVelocity;
    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();  
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            RaycastHit hit;
            // Draws a ray from the main camera to current mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // Checks if the raycast shot hits something that uses NavMesh
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                // MOVEMENT
                // Have the player move to the raycast hit point
                navMeshAgent.destination = hit.point;

                // ROTATION
                Quaternion rotationToLookAt = Quaternion.LookRotation(hit.point - transform.position);
                float rotationY = Mathf.SmoothDampAngle(transform.eulerAngles.y, rotationToLookAt.eulerAngles.y,
                ref rotateVelocity, rotateSpeedMovement * (Time.deltaTime));

                transform.eulerAngles = new Vector3(0, rotationY, 0);
            }
        }
    }
}
