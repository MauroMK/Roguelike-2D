using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Fighter
{
    private bool isAlive = true;

    protected override void ReceiveDamage(Damage dmg)
    {
        if (!isAlive)
        {
            return;
        }

        base.ReceiveDamage(dmg);
        //TODO Refresh the hitpoint bar
    }

    protected override void Die()
    {
        base.Die();
    }
}
