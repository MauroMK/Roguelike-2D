using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Collidable
{
    // Damage structure
    public int[] damagePoint = {1, 2, 3, 4, 5, 6};
    public float[] knockback = {1.5f, 1.7f, 1.9f, 2.1f, 2.3f, 2.5f};

    // Upgrade
    public int weaponLevel = 0;

    // Physics
    private Rigidbody2D bulletRb;
    [SerializeField] private float bulletSpeed;

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
                damageAmount = damagePoint[weaponLevel],
                origin = transform.position,
                knockback = knockback[weaponLevel]
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
