using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExampleGame.GameConotrols;

namespace ExampleGame.Characters
{
    public interface ICharacter
    {
        int PlayerNumber { get; }

        void Move( Vector3 direction, float deltaTime );

        void Jump();

        Vector3 GetPosition();

        public delegate void OnDeathEvent( GameResults gameResult );

        event OnDeathEvent OnDeath;

        void Death();

    }

}