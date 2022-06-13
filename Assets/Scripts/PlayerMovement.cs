using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    [SerializeField]
    private float rotateSpeedMovement = 0.1f;
    public float rotateVelocity;

    private PlayerCombat combatScript;
    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        combatScript = GetComponent<PlayerCombat>();
    }

    void Update()
    {
        if(combatScript.targetedEnemy != null)
        {
            if(combatScript.targetedEnemy.GetComponent<PlayerCombat>() != null)
            {
                if(!combatScript.targetedEnemy.GetComponent<PlayerCombat>().isChampionAlive)
                {
                    combatScript.targetedEnemy = null;
                }
            }
        }

        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            RaycastHit hit;
            // Draws a ray from the main camera to current mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // Checks if the raycast shot hits something that uses NavMesh
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if(hit.collider.tag == "Ground")
                {
                    // MOVEMENT
                    // Have the player move to the raycast hit point
                    navMeshAgent.SetDestination(hit.point);
                    combatScript.targetedEnemy = null;
                    navMeshAgent.stoppingDistance = 0;

                    // ROTATION
                    Quaternion rotationToLookAt = Quaternion.LookRotation(hit.point - transform.position);
                    float rotationY = Mathf.SmoothDampAngle(transform.eulerAngles.y,
                    rotationToLookAt.eulerAngles.y,
                    ref rotateVelocity,
                    rotateSpeedMovement * (Time.deltaTime * 5));

                    transform.eulerAngles = new Vector3(0, rotationY, 0);
                }
            }
        }
    }
}
