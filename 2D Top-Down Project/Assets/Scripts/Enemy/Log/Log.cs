using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : Enemy
{
    private Rigidbody2D rigidbody2d;
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform spawnPosition;
    public Animator anim;

    void Start()
    {
        currentState = EnemyState.idle;
        anim = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        CheckDistance();    
    }

    void CheckDistance()
    {
        if(Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius)
        {
            if (currentState == EnemyState.idle || currentState == EnemyState.walk && currentState != EnemyState.stagger)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.fixedDeltaTime);
                rigidbody2d.MovePosition(temp);
                ChangeState(EnemyState.walk);
                anim.SetBool("wakeUp", true);
            }
            else
            {
                anim.SetBool("wakeUp", false);
            }
        }
    }

    private void ChangeAnim(Vector2 direction)
    {

    }

    private void ChangeState(EnemyState newState)
    {
        if (currentState != newState)
        {
            currentState = newState;
        }
    }

}
