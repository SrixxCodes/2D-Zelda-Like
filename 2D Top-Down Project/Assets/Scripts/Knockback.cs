using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float thrust;
    public float knockTime;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Rigidbody2D enemy = collision.GetComponent<Rigidbody2D>();
            if(enemy != null)
            {
                Vector2 forceDirection = enemy.transform.position - transform.position;
                Vector2 force = forceDirection.normalized * thrust;
                enemy.AddForce(force, ForceMode2D.Impulse);
                StartCoroutine(KnockCoroutine(enemy));
                Debug.Log("couroutine");
            }
        }
    }

    private IEnumerator KnockCoroutine(Rigidbody2D enemy)
    {
        if (enemy != null)
        {
            yield return new WaitForSeconds(knockTime);
            enemy.velocity = Vector2.zero;
        }
        // Old method for knocback

        // enemy.velocity = force;
        // yield return new WaitForSeconds(knockTime);
        // enemy.velocity = Vector2.zero;
    }


}
