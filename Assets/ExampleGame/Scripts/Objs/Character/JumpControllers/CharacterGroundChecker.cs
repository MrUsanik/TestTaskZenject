using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ExampleGame.Characters.JumpControllers
{
    public class CharacterGroundChecker : MonoBehaviour
    {
        private Vector2 offset;
        private Vector2 size;

        private Vector2 pointChecker = Vector2.zero;
        
        private void Awake() {

            BoxCollider2D boxCollider2D = GetComponent<BoxCollider2D>();
            offset = new Vector3( 0f, ( -boxCollider2D.size.y / 2f ) - 0.1f );
            size = new Vector3( boxCollider2D.size.x / 2f, 0.1f );
        }

        public bool IsGrounded() {

            pointChecker.x = transform.position.x;
            pointChecker.y = transform.position.y;

            return Physics2D.OverlapBox( pointChecker + offset, size, 1f, LayerMask.GetMask("Ground") );
        }
    }
}