using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Collidable
{
    // Damage structure
    public float damagePoint;
    public float knockback;
    public float bulletSpeed;

    // Physics
    private Rigidbody2D bulletRb;

    // Reference
    private EnemySoundManager enemySoundManager;

    void Start()
    {
        bulletRb = GetComponent<Rigidbody2D>();
        enemySoundManager = FindObjectOfType<EnemySoundManager>();
    }

    protected override void Update() 
    {
        base.Update();

        MoveBullet();        
    }

    private void MoveBullet()
    {
        transform.Translate(Vector2.right * bulletSpeed * Time.deltaTime);
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(fighterTag))
        {
            // Create a new damage object, then send it to the fighter that have been hit
            Damage dmg = new Damage
            {
                damageAmount = damagePoint,
                origin = transform.position,
                knockback = knockback
            };

            other.SendMessage("ReceiveDamage", dmg);

            enemySoundManager.PlayRandomImpactSound();
            Destroy(this.gameObject);
        }
        
        if (other.gameObject.CompareTag(wallTag))
        {
            enemySoundManager.PlayRandomImpactSound();
            Destroy(this.gameObject);
        }
    }
}
