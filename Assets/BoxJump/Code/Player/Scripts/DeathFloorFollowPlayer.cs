using UnityEngine;

namespace BoxJump.Code.Player.Scripts
{
    public class DeathFloorFollowPlayer : MonoBehaviour
    {
        [SerializeField] private Transform squarePlayer;
        private float _squareHorizontalPosition;
    
    
        private void Awake()
        {
            _squareHorizontalPosition = transform.position.y;
        }

        private void Update()
        {
            transform.position = new Vector2(squarePlayer.position.x, _squareHorizontalPosition);
        }
    }
}
