using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitbox : Collidable
{
    public int damage = 1;
    public float knockbackForce = 1f;

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(fighterTag) && other.name == "Player")
        {
            DealDamage(other);
        }
    }

    private void DealDamage(Collider2D other)
    {
        // Causa o dano no player
        Damage dmg = new Damage
        {
            damageAmount = damage,
            origin = transform.position,
            knockback = knockbackForce
        };

        other.SendMessage("ReceiveDamage", dmg);

        // Aplica o knockback ao player
        Vector2 knockbackDirection = (other.transform.position - transform.position).normalized;
        Vector2 knockbackVector = knockbackDirection * knockbackForce;

        PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
        if (playerMovement != null)
        {
            playerMovement.ApplyKnockback(knockbackVector);
        }
    }
}
