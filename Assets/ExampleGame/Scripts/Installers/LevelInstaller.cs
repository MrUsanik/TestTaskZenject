using ExampleGame.Finish;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace ExampleGame.Installers
{
    public class LevelInstaller : MonoInstaller
    {
        public override void InstallBindings() {

            SceneContext.ExtraBindingsInstallMethod( Container );

            Container
                .BindInterfacesTo<FinishPoint>()
                .FromComponentsInHierarchy()
                .AsCached();
        }
    }
}