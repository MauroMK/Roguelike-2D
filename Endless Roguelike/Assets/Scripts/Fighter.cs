using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    // Public Fields
    public int hitpoint = 25;
    public int maxHitpoint = 25;
    public float pushRecoverySpeed = 0.2f;

    // Immunity
    protected float immuneTime = 1.0f;
    protected float lastImmune;

    // Push
    protected Vector3 pushDirection;

    // All fighters can ReceiveDamage / Die
    protected virtual void ReceiveDamage(Damage dmg)
    {
        if (Time.time - lastImmune > immuneTime)
        {
            lastImmune = Time.time;         // gives the fighter immunity
            hitpoint -= dmg.damageAmount;   // takes damage
            pushDirection = (transform.position - dmg.origin).normalized * dmg.knockback;      // gives a knockback
        }

        if (hitpoint <= 0f)
        {
            hitpoint = 0;
            Die();
        }
    }

    protected virtual void Die()
    {
        // Is meant to be overridden
    }
}
