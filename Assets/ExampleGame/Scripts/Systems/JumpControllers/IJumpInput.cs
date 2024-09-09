using R3;

namespace ExampleGame.JumpControllers
{
    public interface IJumpInput
    {
        Observable<bool> IsJumping { get; }
    }
}