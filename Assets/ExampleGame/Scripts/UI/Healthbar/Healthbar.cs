using ExampleGame.GameConotrols;
using ExampleGame.GameKernel;
using ExampleGame.HealthControllers;
using ExampleGame.JumpControllers;
using R3;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

namespace ExampleGame.UI
{
    public class Healthbar : MonoBehaviour, IInitializable, IDisposable, IGameStartListener, IGameFinishListener
    {
        Observable<int> health;

        [SerializeField]
        private TextMeshProUGUI labelHP;

        [SerializeField]
        private Animator animator;

        private IDisposable subscriptionHP;

        public void Construct( Observable<int> health ) {

            this.health = health;
        }


        void IInitializable.Initialize() {

            Hide();
            SubscribeOnHP();
        }

        void IGameStartListener.OnStartGame() { Show(); }

        void IDisposable.Dispose() { UnsubscribeOnHP(); }

        void IGameFinishListener.OnFinishGame( GameResults gameResults ) { UnsubscribeOnHP(); }


        private void SubscribeOnHP() {

            subscriptionHP = health
               .Subscribe(
                   hp => {  UpdateInfo( hp ); }
               );
        }

        private void UnsubscribeOnHP() {

            subscriptionHP?.Dispose();
            subscriptionHP = null;
        }

        private void Show() { gameObject.SetActive( true ); }

        private void Hide() { gameObject.SetActive( false ); }


        private int curHP = 0;

        private void UpdateInfo( int hp ) {

            //В идеале для анимаций потери|восполнения здоровья нужно сделать отдельный fx контроллер, чтобы не нарушить принцип SRP 
            if( animator != null && hp < curHP ) {

                animator.enabled = true;
                animator.Play( 0 );
            }

            curHP = hp;

            labelHP.text = hp.ToString(); 
        }
    }
}