using ExampleGame.GameKernel;
using ExampleGame.InputController;
using UnityEngine;
using Zenject;
using static ExampleGame.MoveControllers.IMoveInput;

namespace ExampleGame.MoveControllers
{
    public class MoveInput : IMoveInput, IPlayingTickable
    {
        public event MovingDelegate OnMove;

        private readonly ICharacterInputController characterInputController;

        public MoveInput( ICharacterInputController characterInputController ) {

            this.characterInputController = characterInputController;
        }

        public Vector3 MoveDirection { get { return characterInputController.MoveDirection; }  }

        void IPlayingTickable.Tick() {

            Vector3 direction = MoveDirection;
            if ( MoveDirection != Vector3.zero )
                OnMove?.Invoke( direction, Time.deltaTime );
        }
    }
}