using System.Collections;
using BoxJump.Code.LevelGeneration.Scripts;
using BoxJump.Code.Player.Scripts.Extensions;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class LevelGeneratorPlayModeTest
{
    private GameObject _squarePlayerGameObject;

    private StandGenerator _standGenerator;
    private GameObject _standGeneratorGameObject;

    [SetUp]
    public void SetUp()
    {
        _squarePlayerGameObject = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Player/SquarePlayer"));
        _standGeneratorGameObject = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Stand/LevelGenerator"));

        _standGenerator = _standGeneratorGameObject.GetComponent<StandGenerator>();
        _standGenerator.squareTransform = _squarePlayerGameObject.transform;
    }

    [UnityTest]
    public IEnumerator StandDestroyer_WhenStandCollectorTouchStand_DestroyStand()
    {
        //Arrange
        var standDestroyer = _squarePlayerGameObject.transform.Find("StandCollector");
        var spawnedPlatform = _standGenerator.SpawnStand(standDestroyer.position).Find("Stand");
        
        //Act
        _squarePlayerGameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        
        spawnedPlatform.transform.parent = null;
        spawnedPlatform.transform.position = standDestroyer.transform.position;
        
        yield return new WaitForSeconds(2);
        var isNull = spawnedPlatform == null;
        
        //Assert
        Assert.IsTrue(isNull);
    }

    [TearDown]
    public void TearDown()
    {
        Object.Destroy(_squarePlayerGameObject);
        Object.Destroy(_standGeneratorGameObject);
    }
}
