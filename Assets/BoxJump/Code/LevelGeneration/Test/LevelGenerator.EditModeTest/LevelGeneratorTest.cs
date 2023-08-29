using BoxJump.Code.LevelGeneration.Scripts;
using NUnit.Framework;
using UnityEngine;

namespace BoxJump.Code.LevelGeneration.Test.LevelGenerator.EditModeTest
{
    public class LevelGeneratorTest
    {
        private GameObject _squarePlayerGameObject; 
        private GameObject _standGeneratorGameObject;
    
        private StandGenerator _standGenerator;

        [SetUp]
        public void SetUp()
        {
            _squarePlayerGameObject = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Player/SquarePlayer"));
            _standGeneratorGameObject = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Stand/LevelGenerator"));
     
            _standGenerator = _standGeneratorGameObject.GetComponent<StandGenerator>();
            _standGenerator.squareTransform = _squarePlayerGameObject.transform;
        }

        [Test]
        public void SpawnStand_WhenCalled_InstantiatesPlatform()
        {
            // Arrange
            Vector3 spawnPosition = Vector3.zero;

            // Act
            Transform spawnedPlatform = _standGenerator.SpawnStand(spawnPosition);

            // Assert
            Assert.NotNull(spawnedPlatform);
        }
    
        [Test]
        public void RandomStandCharacteristics_ReturnsValidCharacteristics()
        {
            // Act
            StandCharacteristics characteristics = _standGenerator.RandomStandCharacteristics();

            // Assert
            Assert.GreaterOrEqual(characteristics.Scale.x, 2);
            Assert.LessOrEqual(characteristics.Scale.x, 7);
        }
    }
}
