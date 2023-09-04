using System.Collections;
using BoxJump.Code.UI.Scripts;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace BoxJump.Code.UI.Test.UI.PlayModeTest
{
    public class UIJumpButtonTests
    {
        [UnityTest]
        public IEnumerator TestJumpButtonHold_WhenButtonIsHeld_JumpForceIncrease()
        {
            //Arrange
            var gameObjectButton = new GameObject("Button");
            var uiJumpButton = gameObjectButton.AddComponent<UIJumpButton>();

            var gameObjectSlider = new GameObject("Slider");
            var uiSlider = gameObjectSlider.AddComponent<Slider>();

            uiJumpButton.sliderForceBar = uiSlider;
            var initialForce = uiJumpButton.Force;

            //Act
            uiJumpButton.OnPointerDown(null);

            yield return null;

            //Assert
            Assert.Greater(uiJumpButton.Force, initialForce, "The force didn't change");
        }
    }
}