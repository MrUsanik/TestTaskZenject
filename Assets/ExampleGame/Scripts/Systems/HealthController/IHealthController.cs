using R3;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ExampleGame.HealthControllers
{
    public interface IHealthController
    {
        Observable<int> Health { get; }

        void InitHealth();

        void ReduceHP(int value);
        void ReduceAllHP();
    }
}