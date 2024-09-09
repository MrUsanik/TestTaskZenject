using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ExampleGame.Characters
{
    [CreateAssetMenu(
        fileName  = "CharacterData", 
        menuName = "CharactersData/New Character Data" 
    )]

    public class CharacterData : ScriptableObject, ICharacterData
    {
        public int health = 2;
        public float speed = 5.0f;
        public float jumpForce = 5.0f;

        public int Health { get { return health; } }
        public float Speed { get { return speed; } }
        public  float JumpForce { get { return jumpForce; } }
    }

}