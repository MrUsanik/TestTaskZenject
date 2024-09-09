using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace ExampleGame.GameConotrols
{
    public sealed class GameObserverComposite : MonoBehaviour,
        IGameStartListener, 
        IGameFinishListener,
        IGamePauseListener, 
        IGameResumeListener
    {
        [Inject]
        private readonly GameManager gameManager;

        [InjectLocal]
        private readonly List<IGameListeners> listeners = new();

        void Awake() { gameManager.AddListener( this ); }

        void OnDestroy() { gameManager.RemoveListener( this ); }    


        void IGameStartListener.OnStartGame() {

            foreach ( var listener in listeners ) {

                if ( listener is IGameStartListener currentListener )
                    currentListener.OnStartGame();
            }
        }

        void IGameFinishListener.OnFinishGame( GameResults gameResults ) {

            foreach ( var listener in listeners ) {

                if ( listener is IGameFinishListener currentListener )
                    currentListener.OnFinishGame( gameResults );
            }
        }

        void IGamePauseListener.OnPauseGame() {

            foreach ( var listener in listeners ) {

                if ( listener is IGamePauseListener currentListener )
                    currentListener.OnPauseGame();
            }
        }

        void IGameResumeListener.OnResumeGame() {

            foreach ( var listener in listeners ) {

                if ( listener is IGameResumeListener currentListener )
                    currentListener.OnResumeGame();
            }
        }

        
    }
}