using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ExampleGame.GameConotrols
{
    public interface IGameListeners
    {

    }

    public interface IGameStartListener : IGameListeners
    {
        void OnStartGame();
    }

    public interface IGameFinishListener : IGameListeners
    {
        void OnFinishGame( GameResults gameResults );
    }

    public interface IGamePauseListener : IGameListeners
    {
        void OnPauseGame();
    }

    public interface IGameResumeListener : IGameListeners
    {
        void OnResumeGame();
    }

    
    

}