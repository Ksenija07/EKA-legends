using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnimyNavigation : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private EnemyHealth health;
    [SerializeField] private float timeBetweenAttacks = 2;
    private NavMeshAgent navMeshAgent;
    private Animator animator;
    private float lastAttackTime = 0;
    // Start is called before the first frame update
    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health.IsDead())
        {
            navMeshAgent.isStopped = true;
            animator.SetBool("run", false);
        }
        else
        {
            animator.SetBool("run", navMeshAgent.velocity.magnitude > 0.5f);
            navMeshAgent.SetDestination(target.position);
            if (Vector3.Distance(transform.position, target.position) < 2.2f)
            {
                if(Time.time>lastAttackTime + timeBetweenAttacks)
                {
                    animator.SetTrigger("attack");
                    lastAttackTime = Time.time;
                }
            }
        }
    }
}
