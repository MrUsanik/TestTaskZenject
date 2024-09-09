using ExampleGame.GameConotrols;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace ExampleGame.UI
{
    public sealed class PauseScreen : MonoBehaviour, IGamePauseListener, IGameResumeListener
    {
        [SerializeField]
        private Button resumeButton;

        [Inject]
        private GameManager gameManager;

        // Start is called before the first frame update
        void Awake() {

            resumeButton.onClick.AddListener( gameManager.ResumeGame );
        }

        void OnDestroy() {

            resumeButton.onClick.RemoveListener( gameManager.ResumeGame );
        }


        void IGamePauseListener.OnPauseGame() { Show(); }

        void IGameResumeListener.OnResumeGame() { Hide(); }

        private void Show() {

            gameObject.SetActive( true );
        }

        private void Hide() {

            gameObject.SetActive( false );
        }

    }
}