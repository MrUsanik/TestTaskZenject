using ExampleGame.GameConotrols;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace ExampleGame.GameKernel
{
    public class PlayingStateGameKernel : MonoKernel
    {
        [Inject]
        private readonly GameManager gameManager;

        [Inject( Optional = true, Source = InjectSources.Local )]
        private readonly List<IPlayingTickable> playingTickables = new();

        [Inject( Optional = true, Source = InjectSources.Local )]
        private readonly List<IPlayingFixedTickable> playingFixedTickables = new();

        [Inject( Optional = true, Source = InjectSources.Local )]
        private readonly List<IPlayingLateTickable> playingLateTickables = new();

        [Inject( Optional = true, Source = InjectSources.Local )]
        private readonly List<IOnEnable> onEnableListeners = new();

        [Inject( Optional = true, Source = InjectSources.Local )]
        private readonly List<IOnDisable> onDisableListeners = new();

        public override void Update() {

            base.Update();

            if ( gameManager.State != GameState.PLAY ) return;

            foreach ( IPlayingTickable tickable in playingTickables )
                tickable.Tick();
        }


        public override void FixedUpdate() {

            base.FixedUpdate();

            if ( gameManager.State != GameState.PLAY ) return;

            foreach ( IPlayingFixedTickable tickable in playingFixedTickables )
                tickable.FixedTick();
            
        }


        public override void LateUpdate() {

            base.LateUpdate();

            if ( gameManager.State != GameState.PLAY ) return;

            foreach ( IPlayingLateTickable tickable in playingLateTickables )
                tickable.LateTick();
        }

        private void OnEnable() {

            foreach ( IOnEnable listener in onEnableListeners )
                listener.OnEnable();
        }

        private void OnDisable() {

            foreach ( IOnDisable listener in onDisableListeners )
                listener.OnDisable();
        }

    }
}