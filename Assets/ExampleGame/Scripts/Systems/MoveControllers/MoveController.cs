using ExampleGame.Characters;
using ExampleGame.GameConotrols;
using R3;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace ExampleGame.MoveControllers
{
    public class MoveController :
        IGameStartListener,
        IGameFinishListener,
        IGamePauseListener,
        IGameResumeListener,
        IDisposable
    {
        private readonly ICharacter character;
        private readonly IMoveInput moveInput;

        public MoveController( ICharacter character, IMoveInput moveInput ) {

            this.character = character;
            this.moveInput = moveInput;
        }

        void IDisposable.Dispose() { UnsubscrubeOnMove(); }

        void IGameStartListener.OnStartGame() { SubscrubeOnMove(); }

        void IGameFinishListener.OnFinishGame( GameResults gameResults ) { UnsubscrubeOnMove(); }

        void IGamePauseListener.OnPauseGame() { UnsubscrubeOnMove(); }

        void IGameResumeListener.OnResumeGame() { SubscrubeOnMove(); }

        
        private void SubscrubeOnMove() {

            moveInput.OnMove += character.Move; 
        }


        private void UnsubscrubeOnMove() {

            moveInput.OnMove -= character.Move;
        }

    }
}