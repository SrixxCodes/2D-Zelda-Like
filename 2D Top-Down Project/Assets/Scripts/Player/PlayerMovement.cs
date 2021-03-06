using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState{
    walk,
    attack,
    interact,
    stagger,
    idle
}

public class PlayerMovement : MonoBehaviour
{
    public PlayerState currentState;
    public float speed;
    private Rigidbody2D rigidbody2d;
    private Vector3 change;
    private Animator anim;
    public FloatValue currentHealth;
    public Signals playerHealthSignals;
    public VectorValue startingPosition;
    public Inventory inventory;
    public SpriteRenderer receivedItemSprite;

    // Start is called before the first frame update
    void Start()
    {
        currentState = PlayerState.walk;
        anim = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        transform.position = startingPosition.initialValue;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState == PlayerState.interact)
        {
            return;
        }
        if (Input.GetButtonDown("Fire1") && currentState != PlayerState.attack && currentState != PlayerState.stagger) 
        {
            StartCoroutine(AttackCo());
        }
    }

    void FixedUpdate()
    {
        if (currentState == PlayerState.interact)
        {
            return;
        }

        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        if (currentState == PlayerState.walk || currentState == PlayerState.idle)
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
        if (currentState != PlayerState.interact)
        {
            currentState = PlayerState.walk;
        }
    }

    public void RaiseItem()
    {
        if (inventory.currentItem != null) {
            if (currentState != PlayerState.interact)
            {
                anim.SetBool("receiveItem", true);
                currentState = PlayerState.interact;
                receivedItemSprite.sprite = inventory.currentItem.itemSprite;
            }
            else
            {
                anim.SetBool("receiveItem", false);
                currentState = PlayerState.idle;
                receivedItemSprite.sprite = null;
            }
        }
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

    public void Knock(float knockTime, float damage)
    {
        currentHealth.runTimeValue -= damage;
        playerHealthSignals.Raise();

        if (currentHealth.runTimeValue > 0)
        {
            StartCoroutine(KnockCoroutine(knockTime));
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }

    private IEnumerator KnockCoroutine(float knockTime)
    {
        if (rigidbody2d != null)
        {
            yield return new WaitForSeconds(knockTime);
            rigidbody2d.velocity = Vector2.zero;
            currentState = PlayerState.idle;
            rigidbody2d.velocity = Vector2.zero;
        }
        // Old method for knocback

        // enemy.velocity = force;
        // yield return new WaitForSeconds(knockTime);
        // enemy.velocity = Vector2.zero;
    }
}
