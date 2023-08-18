using System.Collections;
using System.Collections.Generic;
using BoxJump.Code.Player.Scripts;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class SquareJumpTest
{
    private GameObject squareObject;
    private Rigidbody2D squareRigidbody2D;
    private SquareController squareController;


    [SetUp]
    public void SetUp()
    {
        //Player Square Object
        squareObject = new GameObject("Square");
        squareObject.AddComponent<BoxCollider2D>();
        squareRigidbody2D = squareObject.AddComponent<Rigidbody2D>();
        squareController = squareObject.AddComponent<SquareController>();
        
        //Ground Object
        GameObject groundObject = new GameObject("Box Ground");
        groundObject.AddComponent<BoxCollider2D>();
        groundObject.tag = "Ground";

        new GameObject().AddComponent<Camera>();
    }
    
    
    [Test]
    public void SquareJump_WhenJumpMethodIsCalled_SquareJumps()
    {
        //Arrange
        squareController.IsGrounded = true; //Set "IsGrounded = true" by default to check if square can jump
        
        //Act
        squareController.Jump(VectorDirection.Up);
        
        //Assert
        Assert.IsTrue(squareController.IsJumping);
    }
    
    [UnityTest]
    public IEnumerator SquareGroundCheck_TouchGround_IsGrounded()
    {
        //Act
        squareObject.transform.position = new Vector3(0, 5, 0);
        
        yield return new WaitForSeconds(2f); //Wait two seconds for the square to fall to the ground
        
        //Assert
        Assert.IsTrue(squareController.IsGrounded);
    }
}
