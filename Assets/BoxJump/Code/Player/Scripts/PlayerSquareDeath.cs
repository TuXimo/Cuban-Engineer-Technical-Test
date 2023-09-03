using System;
using UnityEngine;
using UnityEngine.Events;

namespace BoxJump.Code.Player.Scripts
{
    public class PlayerSquareDeath : MonoBehaviour
    {
        [SerializeField] private UnityEvent deathEvent;

        public bool IsDead { get; private set; }    

        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.CompareTag("DeathGround"))
            {
                IsDead = true;
            }
        }

        private void Update()
        {
            if (IsDead)
            {
                deathEvent.Invoke();
                Destroy(gameObject);
            }
        }
    }
}