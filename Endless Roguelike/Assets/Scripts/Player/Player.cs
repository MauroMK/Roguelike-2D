using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Fighter
{
    private bool isAlive = true;
    public HealthBar healthBar;

    // public int playerLevel = 0;

    protected override void Start()
    {
        base.Start();
        healthBar.UpdateHealthBar(hitpoint, maxHitpoint);
    }

    protected override void ReceiveDamage(Damage dmg)
    {
        if (!isAlive)
        {
            return;
        }

        base.ReceiveDamage(dmg);
        healthBar.UpdateHealthBar(hitpoint, maxHitpoint);
        //TODO Refresh the hitpoint bar
    }

    protected override void ReceiveKnockback(Damage dmg)
    {
        base.ReceiveKnockback(dmg);
    }

    protected override void Die()
    {
        Destroy(gameObject);
    }
}
