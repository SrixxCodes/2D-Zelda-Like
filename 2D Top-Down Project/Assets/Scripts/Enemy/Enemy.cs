using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState { 
    idle,
    walk,
    attack,
    stagger
}

public class Enemy : MonoBehaviour
{
    public EnemyState currentState;
    public FloatValue maxHealth;
    public float health;
    public string enemyName;
    public int baseAttack;
    public float moveSpeed;

    private void Awake()
    {
        health = maxHealth.initialValue;
    }
    private void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }

    public void Knock(Rigidbody2D rigidbody2D, float knockTime, float damage)
    {
        StartCoroutine(KnockCoroutine(rigidbody2D, knockTime));
        TakeDamage(damage);
    }

    private IEnumerator KnockCoroutine(Rigidbody2D rigidbody2D, float knockTime)
    {
        if (rigidbody2D != null)
        {
            yield return new WaitForSeconds(knockTime);
            rigidbody2D.velocity = Vector2.zero;
            currentState = EnemyState.idle;
            rigidbody2D.velocity = Vector2.zero; 
        }
        // Old method for knocback

        // enemy.velocity = force;
        // yield return new WaitForSeconds(knockTime);
        // enemy.velocity = Vector2.zero;
    }

}
