using ExampleGame.Characters;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace ExampleGame.Characters.JumpControllers
{
    public class CharacterJumpController : MonoBehaviour
    {
        private Rigidbody2D rb2D;
        private CharacterGroundChecker groundChecker;

        [Inject]
        private readonly ICharacterData characterData;

        private void Awake() {

            rb2D = GetComponent<Rigidbody2D>();
            groundChecker = gameObject.AddComponent<CharacterGroundChecker>();
        }

        public void Jump() {

            if( groundChecker.IsGrounded() )
                rb2D.AddForce( Vector2.up * characterData.JumpForce, ForceMode2D.Impulse );
        }
    }
}