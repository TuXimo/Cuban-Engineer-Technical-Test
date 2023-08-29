using UnityEngine;
using UnityEngine.UIElements;

namespace BoxJump.Code.LevelGeneration.Scripts
{
    public struct StandCharacteristics
    {
        public readonly Vector2 Scale;
        public readonly Vector2 LocalPosition;

        private float DefaultDistanceFromStand(float distance = 1)
        {
            return distance + Scale.x / 2;
        }

        public StandCharacteristics(Vector2 scale, Vector2 position) : this()
        {
            Scale = scale;
            LocalPosition = new Vector2(DefaultDistanceFromStand(position.x), position.y);
        }
    }
}