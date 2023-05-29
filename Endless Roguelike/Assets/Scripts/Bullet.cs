using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Collidable
{
    // Damage structure
    public int damagePoint;
    public float knockback;
    public float bulletSpeed;

    // Physics
    private Rigidbody2D bulletRb;

    void Start()
    {
        bulletRb = GetComponent<Rigidbody2D>();
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

            Destroy(this.gameObject);
        }
        
        if (other.gameObject.CompareTag(wallTag))
        {
            Destroy(this.gameObject);
        }
    }
}
