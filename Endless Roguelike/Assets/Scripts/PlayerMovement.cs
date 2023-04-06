using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour
{
    private float speed = 3f;

    private Rigidbody2D rb;
    private PlayerInput playerMovementInput;

    private float horizontal;
    private float vertical;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerMovementInput = GetComponent<PlayerInput>();
    }

    void FixedUpdate()
    {
        OnMove();
    }

    void OnMove()
    {
        horizontal = playerMovementInput.actions["Move"].ReadValue<Vector2>().x;
        vertical = playerMovementInput.actions["Move"].ReadValue<Vector2>().y;

        rb.velocity = new Vector2(horizontal * speed, vertical * speed);
    }
}
