using ExampleGame.GameConotrols;
using ExampleGame.InputController;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace ExampleGame.GameControllers
{
    public class GameStateController : IInitializable, IDisposable
    {
        private GameManager gameManager;

        private ICharacterInputController characterInputController;

        [Inject]
        public void Construct( GameManager gameManager, ICharacterInputController characterInputController) {

            this.gameManager = gameManager;
            this.characterInputController = characterInputController;
        }

        void IInitializable.Initialize() {

            characterInputController.Pause += Pause;
        }

        void IDisposable.Dispose() {
            characterInputController.Pause -= Pause;
        }

        private void Pause() {

            gameManager.PauseGame();
        }
    }
}