using ExampleGame.GameConotrols;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace ExampleGame.Installers
{
    [CreateAssetMenu(
        fileName = "Installer (GameCore)",
        menuName = "DI_Installers/New Game Core Installer"
    )]

    //ScriptableObjectInstaller используется в случаях когда одни и теже зависимости прокидываются на нескольких сценах, например в разных режимах игры

    public class GameCoreInstallers : ScriptableObjectInstaller
    {
        public override void InstallBindings() {

            Container.Bind<GameManager>().AsSingle();
        }
    }
}