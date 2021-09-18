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

    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        CheckDistance();    
    }

    void CheckDistance()
    {
        if(Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius)
        {
            Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            rigidbody2d.MovePosition(temp);
        }
    }

}
