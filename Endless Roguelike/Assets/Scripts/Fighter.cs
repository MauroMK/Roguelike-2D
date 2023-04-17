using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Fighter : MonoBehaviour
{
    // Public Fields
    public int hitpoint;
    public int maxHitpoint = 25;
    public float pushRecoverySpeed = 0.2f;

    // Immunity
    protected float immuneTime = 0.5f;
    protected float lastImmune;

    // Push
    protected Vector3 pushDirection;
    private Rigidbody2D rigidBody;

    protected virtual void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        hitpoint = maxHitpoint;
    }

    // All fighters can ReceiveDamage / Die
    protected virtual void ReceiveDamage(Damage dmg)
    {
        if (Time.time - lastImmune > immuneTime)
        {
            lastImmune = Time.time;         // gives the fighter immunity
            hitpoint -= dmg.damageAmount;   // takes damage
            ReceiveKnockback(dmg);
        }

        if (hitpoint <= 0f)
        {
            hitpoint = 0;
            Die();
        }
    }

    protected virtual void ReceiveKnockback(Damage dmg)
    {
        Vector2 direction = (transform.position - dmg.origin).normalized;
        rigidBody.AddForce(direction * dmg.knockback, ForceMode2D.Impulse);
        StartCoroutine(RecoveryTime());
    }

    private IEnumerator RecoveryTime()
    {
        yield return new WaitForSeconds(pushRecoverySpeed);
        rigidBody.velocity = Vector3.zero;
    }

    protected virtual void Die()
    {
        // Is meant to be overridden
    }
}
