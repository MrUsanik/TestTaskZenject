using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ExampleGame.DamageObservers
{
    public interface IDamageObserver
    {
        void Damage( int damage );
    }
}