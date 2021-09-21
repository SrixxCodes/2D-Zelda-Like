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
    public int health;
    public string enemyName;
    public int baseAttack;
    public float moveSpeed;

    public void Knock(Rigidbody2D rigidbody2D, float knockTime)
    {
        StartCoroutine(KnockCoroutine(rigidbody2D, knockTime));
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
