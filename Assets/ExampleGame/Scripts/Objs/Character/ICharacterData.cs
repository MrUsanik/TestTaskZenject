using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ExampleGame.Characters {
    public interface ICharacterData
    {
        int Health { get; }
        float Speed { get; }
        float JumpForce { get; }
    }
}