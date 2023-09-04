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
            GameObject gameObjectButton = new GameObject("Button");
            UIJumpButton uiJumpButton = gameObjectButton.AddComponent<UIJumpButton>();
        
            GameObject gameObjectSlider = new GameObject("Slider");
            Slider uiSlider = gameObjectSlider.AddComponent<Slider>();

            uiJumpButton.sliderForceBar = uiSlider;
            float initialForce = uiJumpButton.Force;
        
            //Act
            uiJumpButton.OnPointerDown(null);

            yield return null;
        
            //Assert
            Assert.Greater(uiJumpButton.Force, initialForce, "The force didn't change");
        }
    }
}
