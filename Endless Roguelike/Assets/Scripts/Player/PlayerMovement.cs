using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb;

    private PlayerInput playerMovementInput;
    private string moveAction = "Move";

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
        horizontal = playerMovementInput.actions[moveAction].ReadValue<Vector2>().x;
        vertical = playerMovementInput.actions[moveAction].ReadValue<Vector2>().y;

        rb.velocity = new Vector2(horizontal * speed, vertical * speed);
    }
}
