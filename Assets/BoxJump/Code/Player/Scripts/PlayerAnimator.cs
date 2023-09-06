using UnityEngine;

namespace BoxJump.Code.Player.Scripts
{
    public class PlayerAnimator : MonoBehaviour
    {
        [SerializeField] private Animator playerAnimator;
        [SerializeField] private PlayerSquareController _playerSquareController;
        
        private readonly int _isGrounded = Animator.StringToHash("isGrounded");
        private readonly int _isJumping = Animator.StringToHash("isJumping");


        private void Update()
        {
            playerAnimator.SetBool(_isGrounded, _playerSquareController.isGrounded);

            if (_playerSquareController.isJumping) playerAnimator.SetTrigger(_isJumping);
        }
    }
}