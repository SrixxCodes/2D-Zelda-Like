using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState{
    walk,
    attack,
    interact
}

public class PlayerMovement : MonoBehaviour
{
    public PlayerState currentState;
    public float speed;
    private Rigidbody2D rigidbody2d;
    private Vector3 change;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        currentState = PlayerState.walk;
        anim = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && currentState != PlayerState.attack) 
        {
            StartCoroutine(AttackCo());
        }
    }

    void FixedUpdate()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        if (currentState == PlayerState.walk)
        {
            UpdateAnimationMove();
        }
    }


    private IEnumerator AttackCo()
    {
        anim.SetBool("attacking", true);
        currentState = PlayerState.attack;
        yield return null;
        anim.SetBool("attacking", false);
        yield return new WaitForSeconds(.3f);
        currentState = PlayerState.walk;

    }

    void UpdateAnimationMove() 
    { 
        if (change != Vector3.zero)
        {
            MoveCharacter();
            anim.SetFloat("moveX", change.x);
            anim.SetFloat("moveY", change.y);
            anim.SetBool("moving", true);
        }
        else
        {
            anim.SetBool("moving", false);
        }
    }

    void MoveCharacter()
    {
        rigidbody2d.MovePosition(transform.position + change.normalized * speed * Time.fixedDeltaTime);
    }

}
