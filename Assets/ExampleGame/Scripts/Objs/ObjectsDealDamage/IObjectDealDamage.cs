using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ExampleGame.ObjectsDealDamage
{
    public interface IObjectDealDamage
    {
        int Damage { get; }

        bool KillWithOneTouch { get; }
    }
}