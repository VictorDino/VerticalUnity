using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Enemy : MonoBehaviour
{
    private NavMeshAgent agent;

    [SerializeField] Transform target;


    private Animator animator;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        MoveToTarget();
    }

    private void MoveToTarget()
    {
        agent.SetDestination(target.position);
        animator.SetFloat("Speed", 1f, 0.3f, Time.deltaTime);

        float distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (distanceToTarget <= agent.stoppingDistance)
        {
            animator.SetFloat("Speed", 0f);
            AttackTarget();
        }
       
        
    }

    private void RotateToTarget()
    {
        transform.LookAt(target);
    }

    private void AttackTarget()
    {
        animator.SetTrigger("Attack");
    }
}
