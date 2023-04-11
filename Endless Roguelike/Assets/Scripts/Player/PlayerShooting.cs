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
    private bool fire;

    void Start()
    {
        playerShootInput = GetComponent<PlayerInput>();
    }

    void Update() 
    {
        HandleAiming();
    }

    void OnFire()
    {
        fire = playerShootInput.actions[fireAction].WasPressedThisFrame();

        if (fire)
        {
            Shoot();
        }

    }

    void Shoot()
    {
        Instantiate(bulletPrefab, barrel.position, barrel.rotation);
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
