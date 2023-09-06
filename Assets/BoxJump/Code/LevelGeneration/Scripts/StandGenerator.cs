using UnityEngine;

namespace BoxJump.Code.LevelGeneration.Scripts
{
    public class StandGenerator : MonoBehaviour
    {
        private const int playerDistanceFromSpawnLevel = 15;

        [SerializeField] private Transform platformTransform;
        [SerializeField] private Transform groundTransform;

        public Transform squareTransform;

        private Vector3 _lastStandEndPosition;

        public bool IsDead { get; private set; } = false;

        private void Awake()
        {
            _lastStandEndPosition = groundTransform.Find("EndPosition").position;
        }

        private void Update()
        {
            GenerateNewPlatforms();
        }

        private void GenerateNewPlatforms()
        {
            if (squareTransform == null)
                return;

            if (_lastStandEndPosition.x - squareTransform.position.x < playerDistanceFromSpawnLevel) SpawnStand();
        }

        public void SpawnStand()
        {
            var lastStandTransform = SpawnStand(new Vector2(_lastStandEndPosition.x,0));
            _lastStandEndPosition = lastStandTransform.Find("Stand/EndPosition").position;
        }

        public Transform SpawnStand(Vector3 spawnPos, float scale = 5)
        {
            var stand = platformTransform.transform.GetChild(0);

            var randomStandCharacteristics = RandomStandCharacteristics();
            stand.transform.localScale = randomStandCharacteristics.Scale;
            stand.transform.localPosition = randomStandCharacteristics.LocalPosition;

            var transformStand = Instantiate(platformTransform, spawnPos, Quaternion.identity);
            return transformStand;
        }

        public StandCharacteristics RandomStandCharacteristics()
        {
            float minScaleValue = 3f, maxScaleValue = 7f;
            float minHorizontalPositionValue = 2f, maxHorizontalPositionValue = 6f;
            float minVerticalPositionValue = -2f, maxVerticalPositionValue = 3f;

            var standCharacteristics = new StandCharacteristics(
                new Vector2(Random.Range(minScaleValue, maxScaleValue), 1),
                new Vector2(Random.Range(minHorizontalPositionValue, maxHorizontalPositionValue),
                    Random.Range(minVerticalPositionValue, maxVerticalPositionValue))
            );

            return standCharacteristics;
        }
    }
}