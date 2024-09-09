using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ExampleGame.ObjectsDealDamage
{
    [CreateAssetMenu(
        fileName = "ObjectsDealDamageData",
        menuName = "ObjectsDealDamageData/New Object Deal DamageData"
    )]

    public class ObjectDealDamageData : ScriptableObject
    {
        public int damage = 1;
        public bool killWithOneTouch = false;
    }
}