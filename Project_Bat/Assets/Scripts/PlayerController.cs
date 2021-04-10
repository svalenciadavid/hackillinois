using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    
    private PlayerInputActions playerInput;
    private Rigidbody2D rb;
    private float moveDirection;

    [SerializeField] float speed = 10f;

    [SerializeField] float attackRange = 1.2f;
    [SerializeField] Transform attackPoint;
    [SerializeField] LayerMask ball;

    private void Awake()
    {
        playerInput = new PlayerInputActions();
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }

    private void FixedUpdate()
    {
        playerInput.Player.Move.performed += ctx => Move(ctx.ReadValue<Vector2>());
        playerInput.Player.Move.canceled += ctx => Move(Vector2.zero);
    }

    private void Move(Vector2 input)
    {
        rb.velocity = (input.normalized) * speed;
    }

    private void Attack()
    {
        Collider2D[] hit = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, ball);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    private void OnAnimatorMove()
    {
        
    }
}
