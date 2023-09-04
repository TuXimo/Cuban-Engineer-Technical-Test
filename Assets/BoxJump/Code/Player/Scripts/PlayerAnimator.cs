using UnityEngine;

namespace BoxJump.Code.Player.Scripts
{
    public class PlayerAnimator : MonoBehaviour
    {
        [SerializeField] private Animator playerAnimator;
        [SerializeField] private PlayerSquareController _playerSquareController;


        private void Update()
        {
            playerAnimator.SetBool("isGrounded", _playerSquareController.isGrounded);

            if (_playerSquareController.isJumping) playerAnimator.SetTrigger("isJumping");
        }
    }
}