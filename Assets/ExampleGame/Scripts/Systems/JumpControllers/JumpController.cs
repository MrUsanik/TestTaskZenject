using ExampleGame.Characters;
using ExampleGame.Characters.JumpControllers;
using ExampleGame.GameConotrols;
using R3;
using System;
using Zenject;

namespace ExampleGame.JumpControllers
{
    public class JumpController :
        IGameStartListener,
        IGameFinishListener,
        IGamePauseListener,
        IGameResumeListener,
        IDisposable
    {
        private readonly ICharacter character;
        private readonly IJumpInput jumpInput;

        private IDisposable subscriptionJump;

        public JumpController( ICharacter character, IJumpInput jumpInput ) {

            this.character = character;
            this.jumpInput = jumpInput;
        }

        void IDisposable.Dispose() { UnsubscrubeOnJump(); }

        void IGameFinishListener.OnFinishGame( GameResults gameResults ) { UnsubscrubeOnJump(); }

        void IGamePauseListener.OnPauseGame() { UnsubscrubeOnJump(); }

        void IGameResumeListener.OnResumeGame() { SubscrubeOnJump(); }

        void IGameStartListener.OnStartGame() { SubscrubeOnJump(); }

        private void SubscrubeOnJump() {

            subscriptionJump = jumpInput.IsJumping
                .Skip(1)
                .Subscribe( 
                    value => {

                        if ( value )
                            character.Jump();
                        //else
                            //character.CancelJump();
                    }
                );
        }

        private void UnsubscrubeOnJump() {

            subscriptionJump?.Dispose();
            subscriptionJump = null;
        }


    }
}