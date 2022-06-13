using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAnimator : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    Animator animator;
    private float motionSmoothTime = .1f;
    // Start is called before the first frame update
    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float speed = navMeshAgent.velocity.magnitude / navMeshAgent.speed;
        animator.SetFloat("speedh", speed, motionSmoothTime, Time.deltaTime);
        animator.SetFloat("speedv", speed, motionSmoothTime, Time.deltaTime);
    }
}
