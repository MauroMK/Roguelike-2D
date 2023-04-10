using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform barrel;

    private PlayerInput playerShootInput;
    private string fireAction = "Fire";
    private bool fire;

    void Start()
    {
        playerShootInput = GetComponent<PlayerInput>();
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
}
