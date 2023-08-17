using System.Collections;
using System.Collections.Generic;
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
        squareObject = new GameObject("Square");
        squareObject.AddComponent<BoxCollider2D>();
        squareRigidbody2D = squareObject.AddComponent<Rigidbody2D>();
        squareController = squareObject.AddComponent<SquareController>();
        
        //Ground
        GameObject groundObject = new GameObject("Box Ground");
        groundObject.AddComponent<BoxCollider2D>();
        groundObject.tag = "Ground";

        new GameObject().AddComponent<Camera>();
    }
    
    
    [Test]
    public void SquareJumpTestSimplePasses()
    {
        //Arrange
        //Set "IsGrounded = true" by default 
        squareController.IsGrounded = true;
        
        //Act
        squareController.Jump(Vector2.up);
        
        //Assert
        Assert.IsTrue(squareController.IsJumping);
    }
    
    [UnityTest]
    public IEnumerator CheckGround_CanJump()
    {
        //Act
        squareObject.transform.position = new Vector3(0, 5, 0);
        
        yield return new WaitForSeconds(2f);
        
        //Assert
        Assert.IsTrue(squareController.IsGrounded);
    }
}
