using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace ExampleGame.Characters.MoveControllers
{
    public class CharacterMoveController : MonoBehaviour
    {
        [Inject]
        private readonly ICharacterData characterData;

        public void Move( Vector3 direction, float deltaTime ) {

            transform.position += direction * ( deltaTime * characterData.Speed );
        }
    }
}