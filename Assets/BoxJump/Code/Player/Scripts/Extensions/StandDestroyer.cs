using System;
using UnityEngine;

namespace BoxJump.Code.Player.Scripts.Extensions
{
    public class StandDestroyer : MonoBehaviour
    {
        [SerializeField] private Transform squarePlayer;
        private float _squareVerticalPosition;
        private float _offset = 20;
        
        private void Awake()
        {
            _squareVerticalPosition = transform.position.y;
        }

        private void Update()
        {
            transform.position = new Vector2(squarePlayer.transform.position.x - _offset, _squareVerticalPosition);
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Ground"))
            {
                Destroy(other.gameObject);
            }
        }
    }
}