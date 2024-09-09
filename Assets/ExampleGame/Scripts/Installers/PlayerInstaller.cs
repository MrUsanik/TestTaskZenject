using ExampleGame.Camera;
using ExampleGame.Characters;
using ExampleGame.DamageObservers;
using ExampleGame.GameControllers;
using ExampleGame.HealthControllers;
using ExampleGame.InputController;
using ExampleGame.JumpControllers;
using ExampleGame.MoveControllers;
using ExampleGame.Observers;
using ExampleGame.UI;
using UnityEngine;
using Zenject;


namespace ExampleGame.Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField]
        private Vector3 cameraOffset = new( 0f, 0f, -10f );

        [SerializeField]
        private CharacterData characterData;

        [SerializeField]
        private Character character;

        [SerializeField]
        private Collider2D characterCollider;

        [SerializeField]
        private PlayerInputController inputController;

        [SerializeField]
        private Healthbar healthbar;

        public override void InstallBindings() {

            Container
                .Bind<ICharacterData>()
                .FromInstance( characterData )
                .AsSingle();

            Container
                .Bind<ICharacter>()
                .FromInstance( character )
                .AsSingle();

            Container
                .Bind<ICharacterInputController>()
                .FromInstance( inputController )
                .AsSingle();

            Container
                .BindInterfacesTo<MoveInput>()
                .AsSingle();

            Container
                .BindInterfacesTo<MoveController>()
                .AsSingle()
                .NonLazy();

            Container
               .Bind<IJumpInput>()
               .To<JumpInput>()
               .AsSingle();

            Container
                .BindInterfacesTo<JumpController>()
                .AsSingle()
                .NonLazy();

            Container.
                BindInterfacesTo<HealthController>()
                .AsSingle()
                .WithArguments( healthbar );
            //Как вариант, Вместо передачи healthbar в HealthController, можно сделать условный HealthbarController на уровне сцены,
            //который будет биндить healthContoller и все healthbar'ы по playerID (playerNumber) 

            Container.
                BindInterfacesTo<DamageObserver>()
                .AsSingle()
                .WithArguments( characterCollider );

            Container
                .Bind<UnityEngine.Camera>()
                .FromComponentInHierarchy()
                .AsSingle();

            Container
                .BindInterfacesTo<CameraFollower>()
                .AsSingle()
                .WithArguments( cameraOffset );

            Container
                .BindInterfacesTo<DeathObserver>()
                .AsSingle();

            Container
                .BindInterfacesTo<GameStateController>()
                .AsSingle();

            Container
                .BindInterfacesTo<Healthbar>()
                .FromInstance( healthbar )
                .AsSingle();

        }
    }

    /* Альтернативный вариант без использования Zenject
    public class PlayerInstaller2 : MonoBehaviour
    {
        [SerializeField]
        private Character character;

        [SerializeField]
        private PlayerInputController inputController;

        private MoveInput moveInput;
        private MoveController moveController;

        private JumpInput jumpInput;
        private JumpController jumpController;

        void Awake() {

            moveInput = new MoveInput( inputController );
            moveController = new MoveController( character, moveInput );

            jumpInput = new JumpInput( inputController );
            jumpController = new JumpController( character, jumpInput );

            //В объекте класса MoveController, нужно каждый кадр вызывать метод ITickable.Tick
            //В объекте класса CameraFollower, нужно после каждого кадра вызывать метод ILateTickable.LateTick
            //В объекте класса JumpController, вызывать методы IInitializable.Initialize и IDisposable.Dispose на Awake и OnDestroy
            //Для этих целей можно написать свой Kernel который будет на старте извлекать из иерархии все объекты реализующие соответствующие соответствующие интерфейсы и делать вызов котрактов
        }
    }*/
}