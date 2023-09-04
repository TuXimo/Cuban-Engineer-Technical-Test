using BoxJump.Code.GameLogic;
using UnityEngine;

namespace BoxJump.Code.Player.Scripts
{
    public class PlayerSquareController : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D squareRigidbody;
        [SerializeField] private PlayerSquareDeath playerSquareDeath;

        [Space] [SerializeField] private SpriteRenderer playerColor;

        [SerializeField] private string playerName;

        [HideInInspector] public bool isJumping;
        [HideInInspector] public bool isGrounded;

        private void Awake()
        {
            playerColor.color = GameManager.PlayerData.Color;
            playerName = GameManager.PlayerData.Name;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Ground"))
            {
                isGrounded = true;
                isJumping = false;
            }
        }

        public void Jump(VectorDirection vectorDirection = VectorDirection.Up, float jumpForce = 10f)
        {
            if (playerSquareDeath.IsDead)
                return;


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

            if (isGrounded)
            {
                isGrounded = false;
                squareRigidbody.AddForce(direction * jumpForce, ForceMode2D.Impulse);
                isJumping = true;
            }
        }
    }
}