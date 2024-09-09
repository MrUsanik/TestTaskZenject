using ExampleGame.Characters.JumpControllers;
using ExampleGame.Characters.MoveControllers;
using ExampleGame.GameConotrols;
using ExampleGame.HealthControllers;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using Zenject;
using static ExampleGame.Characters.ICharacter;

namespace ExampleGame.Characters
{
    public class Character : MonoBehaviour, ICharacter
    {
        public event OnDeathEvent OnDeath;

        [SerializeField]
        private int playerNumber = 1;

        public int PlayerNumber { get { return playerNumber; } }

        [SerializeField]
        private CharacterMoveController moveController;

        [SerializeField]
        private CharacterJumpController jumpController;

        public Vector3 GetPosition() {

            return transform.position;
        }

        public void Move( Vector3 direction, float deltaTime ) {

            moveController.Move( direction, deltaTime );
        }


        public void Jump() { jumpController.Jump(); }


        [ContextMenu("Death")]
        public void Death() {

            gameObject.SetActive( false );
            OnDeath?.Invoke( GameResults.LOSE );  
        }
    }
}