using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private enum AttackType
    {
        Melee,
        Ranged
    }

    private AttackType attackType;
    
    public GameObject targetedEnemy;
    
    private float attackRange;
    private float rotateSpeedAttack;

    private PlayerMovement movementScript;

    public bool basicAtkIdle = false;
    public bool isChampionAlive;
    public bool performMeleeAttack = true;


    // Start is called before the first frame update
    void Awake()
    {
        movementScript = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, targetedEnemy.transform.position) > attackRange)
        {
            // Walking to targetedEnemy position
            movementScript.navMeshAgent.SetDestination(targetedEnemy.transform.position);
            movementScript.navMeshAgent.stoppingDistance = attackRange;

            // Rotation to targetedEnemy position
            Quaternion rotationToLookAt = Quaternion.LookRotation(targetedEnemy.transform.position - transform.position);
            float rotationY = Mathf.SmoothDampAngle(transform.eulerAngles.y, rotationToLookAt.eulerAngles.y,
            ref movementScript.rotateVelocity,
            rotateSpeedAttack * (Time.deltaTime));

            transform.eulerAngles = new Vector3(0, rotationY, 0);
        }  else
        {
            if(attackType == AttackType.Melee)
            {
                if(performMeleeAttack)
                {
                    Debug.Log("Performing a melee attack!");
                }
            }
        }
    }
}
