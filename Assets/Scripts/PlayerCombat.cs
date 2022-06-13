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
    
    [SerializeField]
    private float attackRange = 1f;
    [SerializeField]
    private float rotateSpeedAttack = 0.075f;

    private PlayerMovement movementScript;
    private Stats statsScript;
    private Animator animator;

    public bool basicAtkIdle = false;
    public bool isChampionAlive;
    public bool performMeleeAttack = true;


    // Start is called before the first frame update
    void Awake()
    {
        movementScript = GetComponent<PlayerMovement>();
        statsScript = GetComponent<Stats>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (targetedEnemy != null)
        {
            if (Vector3.Distance(transform.position, targetedEnemy.transform.position) > attackRange)
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
            }
            else
            {
                if (attackType == AttackType.Melee)
                {
                    if (performMeleeAttack)
                    {
                        Debug.Log("Performing a melee attack!");
                        // Start coroutine to attack
                        StartCoroutine(MeleeAttackInterval());
                    }
                }
            }
        }
    }

    IEnumerator MeleeAttackInterval()
    {
        performMeleeAttack = false;
        animator.SetTrigger("Attack");

        yield return new WaitForSeconds(statsScript.attackTime / ((100 + statsScript.attackTime) * 0.01f));

        if(targetedEnemy == null)
        {
            animator.ResetTrigger("Attack");
            performMeleeAttack = true;
        }
     
    }

    void MeleeAttack()
    {
        if (targetedEnemy != null)
        {
            if(targetedEnemy.GetComponent<Targetable>().targetedEnemyType == Targetable.EnemyType.Minion)
            {
                targetedEnemy.GetComponent<Stats>().health -= statsScript.attackDamage;
            }
        }

        performMeleeAttack = true;
    }
}
