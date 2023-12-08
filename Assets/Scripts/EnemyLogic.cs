using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyLogic : MonoBehaviour
{
    public float hitPoints = 100f;
    public float turnSpeed = 15f;
    public Transform target;
    public float ChaseRange;
    private NavMeshAgent agent;
    private float DistanceToTarget;
    private float DistanceToDefault;
    private Animator anim;
    Vector3 DefaultPosition;

    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<PlayerLogic>().transform;
        agent = this.GetComponent<NavMeshAgent>();
        anim = this.GetComponentInChildren<Animator>();
        DefaultPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        DistanceToTarget = Vector3.Distance(target.position, transform.position);
        DistanceToDefault = Vector3.Distance(DefaultPosition, transform.position);

        if (DistanceToTarget <= ChaseRange)
        {

            if (DistanceToTarget > agent.stoppingDistance)
            {
                ChaseTarget();
            }
            else if (DistanceToTarget <= agent.stoppingDistance)
            {
                Attack();
            }
        }
        else if (DistanceToTarget > ChaseRange * 2)
        {
            agent.SetDestination(DefaultPosition);
            FaceTarget(DefaultPosition);

            if (DistanceToDefault <= agent.stoppingDistance)
            {
                Debug.Log("Time to stop");
                anim.SetBool("Run", false);
                anim.SetBool("Attack", false);
            }
        }
    }

    private void FaceTarget(Vector3 destination)
    {
        Vector3 direction = (destination - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    public void HitConnect()
    {
        if (DistanceToTarget <= agent.stoppingDistance)
        {
            //target.GetComponent<PlayerLogic>().PlayerGetHit(50f);
        }
    }

    public void TakeDamage(float damage)
    {
        hitPoints -= damage;
        anim.SetTrigger("GetHit");
        anim.SetFloat("Hitpoint", hitPoints);

        if (hitPoints <= 0)
        {
            Destroy(gameObject, 3f);
        }
    }

    public void Attack()
    {
        Debug.Log("attack");
        anim.SetBool("Run", false);
        anim.SetBool("Attack", true);
    }

    public void ChaseTarget()
    {
        agent.SetDestination(target.position);
        anim.SetBool("Run", true);
        anim.SetBool("Attack", false);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, ChaseRange);
    }
}