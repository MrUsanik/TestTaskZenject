using R3;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ExampleGame.MoveControllers
{
    public interface IMoveInput
    {
        public delegate void MovingDelegate( Vector3 direction, float deltaTime );

        event MovingDelegate OnMove;

        Vector3 MoveDirection { get; }
    }
}