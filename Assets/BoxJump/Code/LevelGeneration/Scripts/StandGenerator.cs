using BoxJump.Code.LevelGeneration.Scripts;
using UnityEngine;

public class StandGenerator : MonoBehaviour
{
    private const int playerDistanceFromSpawnLevel = 15;
    
    [SerializeField] private Transform platformTransform;
    [SerializeField] private Transform groundTransform;
    
    public Transform squareTransform;
    
    private Vector3 lastStandEndPosition;
    
    private void Awake()
    {
        lastStandEndPosition = groundTransform.Find("EndPosition").position;
    }

    private void Update()
    {
        GenerateNewPlatforms();
    }

    private void GenerateNewPlatforms()
    {
        if (lastStandEndPosition.x - squareTransform.position.x < playerDistanceFromSpawnLevel)
        {
            SpawnStand();
        }
    }

    public void SpawnStand()
    {
        Transform lastStandTransform = SpawnStand(lastStandEndPosition);
        lastStandEndPosition = lastStandTransform.Find("Stand/EndPosition").position;
    }

    public Transform SpawnStand(Vector3 spawnPos, float scale = 5)
    {
        Transform stand = platformTransform.transform.GetChild(0);

        StandCharacteristics randomStandCharacteristics = RandomStandCharacteristics();
        stand.transform.localScale = randomStandCharacteristics.Scale;
        stand.transform.position = randomStandCharacteristics.LocalPosition;

        Transform transformStand = Instantiate(platformTransform, spawnPos, Quaternion.identity);
        return transformStand;
    }

    public StandCharacteristics RandomStandCharacteristics()
    {
        int minScaleValue = 2, maxScaleValue = 7;
        float minHorizontalPositionValue = 2f, maxHorizontalPositionValue = 4f;
        float minVerticalPositionValue = -2f, maxVerticalPositionValue = 1.5f;

        StandCharacteristics standCharacteristics = new StandCharacteristics(
            new Vector2(Random.Range(minScaleValue, maxScaleValue), 1),
            new Vector2(Random.Range(minHorizontalPositionValue, maxHorizontalPositionValue),
                Random.Range(minVerticalPositionValue, maxVerticalPositionValue))
        );

        return standCharacteristics;
    }
}
