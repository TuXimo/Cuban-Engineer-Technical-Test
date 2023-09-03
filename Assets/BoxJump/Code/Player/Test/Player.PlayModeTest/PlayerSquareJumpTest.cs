using System.Collections;
using BoxJump.Code.Player.Scripts;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerSquareJumpTest
{
    private GameObject _squareObject;
    private Rigidbody2D _squareRigidbody2D;
    private PlayerSquareController _playerSquareController;


    [SetUp]
    public void SetUp()
    {
        _squareObject = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Player/SquarePlayer"));
        _squareRigidbody2D = _squareObject.GetComponent<Rigidbody2D>();
        _playerSquareController = _squareObject.GetComponent<PlayerSquareController>();

        new GameObject().AddComponent<Camera>();
    }
    
    
    [Test]
    public void SquareJump_WhenJumpMethodIsCalled_SquareJumps()
    {
        //Arrange
        _playerSquareController.isGrounded = true; //Set "IsGrounded = true" by default to check if square can jump

        //Act
        _playerSquareController.Jump();
        
        //Assert
        Assert.IsTrue(_playerSquareController.isJumping);
    }
    
    [UnityTest]
    public IEnumerator SquareGroundCheck_TouchGround_IsGrounded()
    {
        //Ground Arrange
        GameObject groundObject = new GameObject("Box Ground");
        groundObject.AddComponent<BoxCollider2D>();
        groundObject.tag = "Ground";
        
        //Act
        _squareObject.transform.position = new Vector3(0, 5, 0);
        yield return new WaitForSeconds(2f); //Wait two seconds for the square to fall to the ground
        
        //Assert
        Assert.IsTrue(_playerSquareController.isGrounded);
    }

    [Test]
    [TestCase(10)]
    [TestCase(5)]
    [TestCase(2)]
    [TestCase(0)]
    public void SquareFalls_TouchTrigger_PlayerDie(float squareYPosition)
    {
        //Arrange
        GameObject deathGroundObject = new GameObject("Death Ground");
        deathGroundObject.AddComponent<BoxCollider2D>().isTrigger = true;
        deathGroundObject.tag = "DeathGround";

        var playerSquareDeath = _squareObject.GetComponent<PlayerSquareDeath>();
        _squareObject.transform.position = new Vector3(0, squareYPosition);
        
        //Check if the player's position is in the death ground position and then die.
        Debug.Log(playerSquareDeath.IsDead);
        Assert.IsTrue(playerSquareDeath.IsDead == (deathGroundObject.transform.position.y == _squareObject.transform.position.y));
    }
    
    [UnityTest]
    public IEnumerator SquareFalls_TouchTrigger_PlayerDie2()
    {
        //Arrange
        GameObject deathGroundObject = new GameObject("Death Ground");
        deathGroundObject.AddComponent<BoxCollider2D>().isTrigger = true;
        deathGroundObject.tag = "DeathGround";

        var playerSquareDeath = _squareObject.GetComponent<PlayerSquareDeath>();
        deathGroundObject.transform.position = _squareObject.transform.position;
        
        //Check if the player's position is in the death ground position and then die.
        yield return null;
        Assert.IsTrue(playerSquareDeath.IsDead);
    }
}
