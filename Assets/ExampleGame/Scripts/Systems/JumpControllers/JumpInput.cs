using ExampleGame.InputController;
using R3;

namespace ExampleGame.JumpControllers
{
    public class JumpInput : IJumpInput
    {
        private readonly ICharacterInputController characterInputController;

        public JumpInput( ICharacterInputController characterInputController ) {

            this.characterInputController = characterInputController;
        }

        Observable<bool> IJumpInput.IsJumping { get { return characterInputController.IsJumping; } }
    }
}