using R3;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ExampleGame.InputController
{
    public interface ICharacterInputController 
    {
        Vector3 MoveDirection { get; }

        ReactiveProperty<bool> IsJumping { get; }

        event Action Pause;
    }
}