using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ExampleGame.ObjectsDealDamage
{
    public class ObjectDealDamage : MonoBehaviour, IObjectDealDamage
    {
        [SerializeField]
        private ObjectDealDamageData objectDealDamageData;

        int IObjectDealDamage.Damage => objectDealDamageData.damage;

        bool IObjectDealDamage.KillWithOneTouch => objectDealDamageData.killWithOneTouch;
    }
}