using ExampleGame.Characters;
using ExampleGame.GameConotrols;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace ExampleGame.Observers
{
    public class DeathObserver : IGameStartListener, IGameFinishListener, IDisposable
    {
        private readonly ICharacter character;
        private readonly GameManager gameManager;

        public DeathObserver( ICharacter character, GameManager gameManager ) {

            this.character = character;
            this.gameManager = gameManager;
        }

        private void OnDeath( GameResults gameResults ) {

            gameManager.FinishGame( gameResults );
        }

        void IGameStartListener.OnStartGame() {
            character.OnDeath += OnDeath;
        }

        void IGameFinishListener.OnFinishGame( GameResults gameResults ) {
            character.OnDeath -= OnDeath;
        }

        void IDisposable.Dispose() {
            character.OnDeath -= OnDeath;
        }

    }
}