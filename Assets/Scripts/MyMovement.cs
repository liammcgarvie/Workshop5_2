using UnityEngine;
using UnityEngine.InputSystem;

public class MyMovement : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float maxSpeed = 10f;
    [SerializeField] private float jumpForce = 10f;
    
    public bool controlEnabled { get; set; }

    private Vector2 moveInput;
    private Vector2 startPosition;
    private bool isGrounded;

    private Rigidbody2D rb;
    private CircleCollider2D groundCheckCollider;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        
        groundCheckCollider = GetComponent<CircleCollider2D>();
        groundCheckCollider.isTrigger = true;
        
        controlEnabled = true;
        
        startPosition = transform.position;
    }

    private void FixedUpdate()
    {
        Vector2 currentVelocity = rb.velocity;
        rb.velocity = new Vector2(TranslateInputToVelocityX(moveInput), currentVelocity.y);
        
        isGrounded = IsGrounded();
    }
    
    private bool IsGrounded()
    {
        if (groundCheckCollider.IsTouchingLayers(groundLayer))
        {
            return true;
        }
        
        return false;
    }

    float TranslateInputToVelocityX(Vector2 input)
    {
        return input.x * maxSpeed;
    }
    
    public void PositionReset()
    {
        transform.position = startPosition;
    }

    private void Jump()
    {
        if (isGrounded)
        {
            rb.AddForce(new Vector2(0, jumpForce));
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (controlEnabled)
        {
            moveInput = context.ReadValue<Vector2>().normalized;
        }
        else
        {
            moveInput = Vector2.zero;
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log("Jump!");
            Jump();
        }

        if (context.canceled && controlEnabled)
        {
            // Additional logic for jump can go here if needed
        }
    }
}

