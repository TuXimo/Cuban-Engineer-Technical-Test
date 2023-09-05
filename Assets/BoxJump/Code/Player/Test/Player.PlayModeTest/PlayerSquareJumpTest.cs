using System.Collections;
using BoxJump.Code.Player.Scripts;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace BoxJump.Code.Player.Test.Player.PlayModeTest
{
    public class PlayerSquareJumpTest
    {
        private PlayerSquareController _playerSquareController;
        private GameObject _squareGameObject;


        [SetUp]
        public void SetUp()
        {
            _squareGameObject = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Player/SquarePlayer"));
            _playerSquareController = _squareGameObject.GetComponent<PlayerSquareController>();
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
            var groundObject = new GameObject("Box Ground");
            groundObject.AddComponent<BoxCollider2D>();
            groundObject.tag = "Ground";

            //Act
            _squareGameObject.transform.position = new Vector3(0, 5, 0);
            yield return new WaitForSeconds(2f); //Wait two seconds for the square to fall to the ground

            //Assert
            Assert.IsTrue(_playerSquareController.isGrounded);
        }

        [UnityTest]
        [TestCase(0, ExpectedResult = null)]
        [TestCase(2, ExpectedResult = null)]
        [TestCase(4, ExpectedResult = null)]
        [TestCase(6, ExpectedResult = null)]
        public IEnumerator SquareFallsOut_TouchTriggerWithPositiveHeight_PlayerDies(
            float distanceBetweenDeathFloorAndPlayer)
        {
            //Arrange
            var deathGroundObject = _squareGameObject.transform.GetChild(0).gameObject;
            deathGroundObject.transform.position = new Vector3(0,
                _squareGameObject.transform.position.y - distanceBetweenDeathFloorAndPlayer);
            yield return null;

            var playerSquareDeath = _squareGameObject.GetComponent<PlayerSquareDeath>();

            yield return new WaitForFixedUpdate();
            //Checks if the player is above the trigger and matches the player is still alive
            Assert.IsTrue(!playerSquareDeath.IsDead ==
                          deathGroundObject.transform.position.y <= _squareGameObject.transform.position.y);
        }

        [TearDown]
        public void TearDown()
        {
            Object.Destroy(_squareGameObject);
            Object.Destroy(_playerSquareController);

            foreach (var gameObject in GameObject.FindGameObjectsWithTag("Ground"))
            {
                Object.Destroy(gameObject);
            }
        }
    }
}