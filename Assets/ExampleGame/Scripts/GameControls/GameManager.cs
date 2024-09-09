using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace ExampleGame.GameConotrols
{
    public sealed class GameManager : IInitializable
    {
        public GameState State { get; private set; } = GameState.OFF;

        private readonly List<IGameListeners> listeners = new();

        public void AddListener( IGameListeners listener ) { listeners.Add( listener ); }

        public void RemoveListener( IGameListeners listener ) { listeners.Remove( listener ); }

        void IInitializable.Initialize() { Time.timeScale = 0f; }

        public void StartGame() {

            if ( State != GameState.OFF ) return;

            State = GameState.PLAY;

            foreach ( var listener in listeners ) {

                if ( listener is IGameStartListener currentListener )
                    currentListener.OnStartGame();
            }

            Time.timeScale = 1f;
        }

        public void FinishGame( GameResults gameResults ) {

            if ( State != GameState.PLAY ) return;

            State = GameState.FINISH;

            foreach ( var listener in listeners ) {

                if ( listener is IGameFinishListener currentListener )
                    currentListener.OnFinishGame( gameResults );
            }

            Time.timeScale = 0f;
        }

        public void PauseGame() {

            if ( State != GameState.PLAY ) return;

            State = GameState.PAUSE;

            foreach ( var listener in listeners ) {

                if ( listener is IGamePauseListener currentListener )
                    currentListener.OnPauseGame();
            }

            Time.timeScale = 0f;
        }

        public void ResumeGame() {

            if ( State != GameState.PAUSE ) return;

            State = GameState.PLAY;

            foreach ( var listener in listeners ) {

                if ( listener is IGameResumeListener currentListener )
                    currentListener.OnResumeGame();
            }

            Time.timeScale = 1f;
        }
    }

}