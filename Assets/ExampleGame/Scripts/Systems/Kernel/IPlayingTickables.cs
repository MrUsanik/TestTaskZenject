using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ExampleGame.GameKernel
{
    public interface IPlayingTickable { void Tick(); }
    public interface IPlayingFixedTickable { void FixedTick(); }
    public interface IPlayingLateTickable { void LateTick(); }
    public interface IOnEnable { void OnEnable(); }
    public interface IOnDisable{ void OnDisable(); }

}