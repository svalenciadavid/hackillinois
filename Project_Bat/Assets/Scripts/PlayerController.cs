using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    
    private PlayerInputActions playerInput;
    private Rigidbody2D rb;
    [SerializeField] float speed = 10f;

    private void Awake()
    {
        playerInput = new PlayerInputActions();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 moveInput = playerInput.Player.Move.ReadValue<Vector2>();
        rb.velocity = moveInput * speed;
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }

    private void ProcessInput()
    {

    }

    private void OnAnimatorMove()
    {
        
    }
}
