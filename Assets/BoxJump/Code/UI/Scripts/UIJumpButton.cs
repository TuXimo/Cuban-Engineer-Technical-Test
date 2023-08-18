using System;
using BoxJump.Code.Player.Scripts;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace BoxJump.Code.UI.Scripts
{
    public class UIJumpButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
    {
        [SerializeField] private bool isButtonPressed;
        [SerializeField] private SquareController squareController;
        [SerializeField] private VectorDirection direction;
        
        public Slider sliderForceBar;

        private const int AccelerationInput = 6;
        private const int MaxJumpForce = 15;
        public float Force { get; private set; }
        private readonly float _initialForce = 1;

        public void OnPointerUp(PointerEventData eventData)
        {
            isButtonPressed = false;
            
            squareController.Jump(direction, Force);
            Force = _initialForce;
            
            sliderForceBar.value = Force;
        }
        
        public void OnPointerDown(PointerEventData eventData)
        {
            isButtonPressed = true;
        }

        private void Update()
        {
            if(isButtonPressed && Force < MaxJumpForce)
            {
                Force += Time.deltaTime * AccelerationInput;
                sliderForceBar.value = Force;
            }
        }
    }
}