using ExampleGame.Characters;
using ExampleGame.MoveControllers;
using R3;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace ExampleGame.InputController
{
    public class PlayerInputController : MonoBehaviour, ICharacterInputController
    {
        [SerializeField]
        private PlayerInput playerInput;

        private InputAction inputActionJump;

        private void Awake() {

            inputActionJump = playerInput.actions.FindAction( "Jump" );
        }

        void OnEnable() {

            playerInput.actions.Enable();
            inputActionJump.started += StartJumping;
            inputActionJump.canceled += CompleteJumping;
        }

        void OnDisable() {

            playerInput.actions.Disable();
            inputActionJump.started -= StartJumping;
            inputActionJump.canceled -= CompleteJumping;
        }


        private Vector3 direction = Vector3.zero;

        public Vector3 MoveDirection => direction;

        public void OnMovement( InputValue value ) {

            direction.x = value.Get<Vector2>().x;
        }

        public ReactiveProperty<bool> IsJumping { get; } = new( false );

        public void StartJumping( InputAction.CallbackContext context) {

            IsJumping.Value = true;
        }

        public void CompleteJumping( InputAction.CallbackContext context ) {

            IsJumping.Value = false;
        }

        public event Action Pause;

        public void OnPause( InputValue value ) {

            Pause?.Invoke();
        }

    }
}