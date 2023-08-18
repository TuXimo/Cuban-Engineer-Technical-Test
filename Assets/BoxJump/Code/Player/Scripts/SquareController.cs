using System;
using BoxJump.Code.Player.Scripts;
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

    public void Jump(VectorDirection vectorDirection = VectorDirection.Up, float jumpForce = 10f)
    {
        Vector2 direction = default;
        
        //Lock directions
        switch (vectorDirection)
        {
            case VectorDirection.Up:
                direction = new Vector2(0, 1);
                break;
            case VectorDirection.UpRight:
                direction = new Vector2(0.5f, 1);
                break;
            case VectorDirection.UpLeft:
                direction = new Vector2(-0.5f, 1);
                break;
        }
        
        if(IsGrounded)
        {
            IsGrounded = false;
            squareRigidbody.AddForce(direction * jumpForce, ForceMode2D.Impulse);
            IsJumping = true;
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