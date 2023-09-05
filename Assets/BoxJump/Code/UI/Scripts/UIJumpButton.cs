using BoxJump.Code.Player.Scripts;
using BoxJump.Code.Player.Scripts.Extensions;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace BoxJump.Code.UI.Scripts
{
    public class UIJumpButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
    {
        private const int AccelerationInput = 6;
        private const int MaxJumpForce = 15;
        [SerializeField] private bool isButtonPressed;
        [SerializeField] private PlayerSquareController playerSquareController;
        [SerializeField] private VectorDirection direction;

        public Slider sliderForceBar;
        private readonly float _initialForce = 1;
        public float Force { get; private set; }

        private void Update()
        {
            if (isButtonPressed && Force < MaxJumpForce)
            {
                Force += Time.deltaTime * AccelerationInput;
                sliderForceBar.value = Force;
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            isButtonPressed = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            isButtonPressed = false;

            playerSquareController.Jump(direction, Force);
            Force = _initialForce;

            sliderForceBar.value = Force;
        }
    }
}