using ExampleGame.MoveControllers;
using ExampleGame.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace ExampleGame.Installers
{
    public class UIInstaller : MonoInstaller
    {
        [SerializeField]
        private StartScreen startScreen;

        [SerializeField]
        private PauseScreen pauseScreen;

        [SerializeField]
        private FinishScreen finishScreen;

        public override void InstallBindings() {

            Container
                .BindInterfacesTo<StartScreen>()
                .FromInstance( startScreen );

            Container
                .BindInterfacesTo<PauseScreen>()
                .FromInstance( pauseScreen );

            Container
                .BindInterfacesTo<FinishScreen>()
                .FromInstance( finishScreen );
        }
    }
}