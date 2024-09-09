using ExampleGame.GameConotrols;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace ExampleGame.MoveControllers
{
    public class FinishScreen : MonoBehaviour, IInitializable, IGameFinishListener
    {
        [SerializeField]
        private GameObject winScreen;

        [SerializeField]
        private GameObject loseScreen;

        void IInitializable.Initialize() {
            gameObject.SetActive( false );
        }

        void IGameFinishListener.OnFinishGame( GameResults gameResult ) {

            winScreen.SetActive( gameResult == GameResults.WIN );
            loseScreen.SetActive( gameResult == GameResults.LOSE );

            gameObject.SetActive( true );
        }
    }
}