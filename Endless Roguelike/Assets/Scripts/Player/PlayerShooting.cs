using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform barrel;
    [SerializeField] private SpriteRenderer slimeSprite;

    private PlayerInput playerShootInput;
    private string fireAction = "Fire";

    private float shootInterval = 0f;
    
    public float fireRate = 2f;

    void Awake()
    {
        playerShootInput = GetComponent<PlayerInput>();
    }

    void Update() 
    {
        HandleAiming();
        HandleFiring();
    }

    void HandleFiring()
    {
        var fire = playerShootInput.actions[fireAction];

        if (fire.ReadValue<float>() > 0f && Time.time > shootInterval)
        {
            Shoot();
            CameraShaker.Invoke(); //Shakes the camera
        }
    }

    private void Shoot()
    {
        Instantiate(bulletPrefab, barrel.position, barrel.rotation);
        shootInterval = Time.time + fireRate;
    }

    void HandleAiming()
    {
        // Rotation
        var direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3 (0, 0, angle);

        if (angle > 90 || angle < -90)
        {
            slimeSprite.flipX = false;
        }
        else
        {
            slimeSprite.flipX = true;
        }
    }
}
