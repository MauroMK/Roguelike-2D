using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Fighter
{
    [SerializeField] private float speed;
    
    public int xpValue = 1;

    private Transform playerTransform;

    protected override void Start()
    {
        base.Start();
        playerTransform = GameManager.instance.player.transform;
    }

    protected virtual void FixedUpdate() 
    {
        // Follow the player
        transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
    }

    protected override void ReceiveDamage(Damage dmg)
    {
        base.ReceiveDamage(dmg);
    }

    protected override void ReceiveKnockback(Damage dmg)
    {
        base.ReceiveKnockback(dmg);
    }

    protected override void Die()
    {
        GameManager.instance.AddExperience(xpValue);
        Destroy(gameObject);
    }

    
}
