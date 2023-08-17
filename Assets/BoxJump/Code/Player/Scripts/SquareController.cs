using System;
using UnityEngine;

public class SquareController : MonoBehaviour
{
    [SerializeField] private float squareJumpForce = 10.0f;
    [SerializeField] private Rigidbody2D squareRigidbody;
    public bool IsJumping;
    public bool IsGrounded;


    private void Awake()
    {
        squareRigidbody = GetComponent<Rigidbody2D>();
    }

    public void Jump(float jumpForce = 10f)
    {
        //Square by default jumps diagonally
        Vector2 direction = new Vector2(0.5f, 1);
        
        if(IsGrounded)
        {
            IsGrounded = false;
            squareRigidbody.AddForce(direction * jumpForce, ForceMode2D.Impulse);
            IsJumping = true;
        }
    }
    
    public void Jump(Vector2 direction, float jumpForce = 10f)
    {
        if(IsGrounded)
        {
            IsGrounded = false;
            squareRigidbody.AddForce(direction * jumpForce, ForceMode2D.Impulse);
            IsJumping = true;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump(squareJumpForce);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            IsGrounded = true;
            IsJumping = false;
        }
    }
}