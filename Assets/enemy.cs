using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class enemy : MonoBehaviour
{

    NavMeshAgent nm;
    public Transform target;

    public float distanceThreshold = 10f;
    public enum AIState { idle,chasing,attack};
    public AIState aiState = AIState.idle;
    public Animator animator;

    float dist;
    public float attackThreshold = 1.5f;

    // Start is called before the first frame update
    void Start()
    {

        nm = GetComponent<NavMeshAgent>();
        StartCoroutine(Think());
        target = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(target.position, transform.position);
        if (dist < 25){
        nm.SetDestination(target.position);
        }
        
    }

    IEnumerator Think()
    {
        while(true)
        {
            switch (aiState)
            {
                case AIState.idle:
                    dist = Vector3.Distance(target.position, transform.position);
                    if (dist < distanceThreshold)
                    {
                        aiState = AIState.chasing;
                        animator.SetBool("chasing",true);
                    }
                    nm.SetDestination(transform.position);
                    break;

                case AIState.chasing:
                    dist = Vector3.Distance(target.position, transform.position);
                    if (dist > distanceThreshold)
                    {
                        aiState = AIState.idle;
                        animator.SetBool("chasing",false);
                    }
                    if (dist < attackThreshold)
                    {
                        aiState = AIState.attack;
                        animator.SetBool("attacking",true);

                    }
                    nm.SetDestination(transform.position);
                    break;

                case AIState.attack:
                    nm.SetDestination(transform.position);
                    dist = Vector3.Distance(target.position, transform.position);
                    if (dist > attackThreshold)
                    {
                        aiState = AIState.chasing;
                        animator.SetBool("attacking",false);
                    }
                    break;
                default:
                    break;
            }
            yield return new WaitForSeconds(1.0f);
        }
    }
}
