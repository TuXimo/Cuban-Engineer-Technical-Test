using BoxJump.Code.GameLogic;
using UnityEngine;

namespace BoxJump.Code.Player.Scripts
{
    public class PlayerSquareScore : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("StandTrigger"))
            {
                GameManager.Score++;
                Destroy(other.gameObject);
            }
        }
    }
}