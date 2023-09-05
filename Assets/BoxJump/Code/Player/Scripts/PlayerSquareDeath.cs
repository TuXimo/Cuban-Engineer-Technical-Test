using BoxJump.Code.GameLogic;
using UnityEngine;
using UnityEngine.Events;

namespace BoxJump.Code.Player.Scripts
{
    public class PlayerSquareDeath : MonoBehaviour
    {
        [SerializeField] private UnityEvent deathEvent;
        [SerializeField] private GameManager gameManager;

        public bool IsDead { get; private set; }

        private void Update()
        {
            if (IsDead) OnPlayerDeath();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("DeathGround")) IsDead = true;
        }

        private void OnPlayerDeath()
        {
            deathEvent.Invoke();

            if(gameManager != null)
            {
                gameManager.CheckHighScore();
            }

            Destroy(gameObject);
        }
    }
}