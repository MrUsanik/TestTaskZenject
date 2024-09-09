using ExampleGame.GameConotrols;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace ExampleGame.UI
{
    public sealed class StartScreen : MonoBehaviour, IInitializable, IGameStartListener
    {
        [SerializeField]
        private Button startButton;

        [Inject]
        private GameManager gameManager;

        void IInitializable.Initialize() { Show(); }

        void IGameStartListener.OnStartGame() { Hide(); }

        private void Show() {

            gameObject.SetActive( true );
            startButton.onClick.AddListener( gameManager.StartGame );
        }

        private void Hide() {

            gameObject.SetActive( false );
            startButton.onClick.RemoveListener( gameManager.StartGame );
        }
    }
}
