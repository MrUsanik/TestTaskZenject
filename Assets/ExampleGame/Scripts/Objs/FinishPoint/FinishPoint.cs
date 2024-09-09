using ExampleGame.GameConotrols;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using R3;
using R3.Triggers;

namespace ExampleGame.Finish
{

    public class FinishPoint : MonoBehaviour
    {
        [Inject]
        private GameManager gameManager;

        [SerializeField]
        private new Collider2D collider2D;

        private IDisposable subscritionOnTrigger;

        void OnEnable() {
            SubscripbeOnTrigger();
        }

        void OnDisable() {
            UnsubscripbeOnTrigger();
        }

        private void SubscripbeOnTrigger() {

            subscritionOnTrigger = collider2D.OnTriggerEnter2DAsObservable()
            .Subscribe( 
                _ => { 
                    if ( _.CompareTag( ListTags.PLAYER ) ) 
                        gameManager.FinishGame( GameResults.WIN ); 
                } 
            );
        }

        private void UnsubscripbeOnTrigger() {

            subscritionOnTrigger.Dispose();
            subscritionOnTrigger = null;
        }

        private void OnTriggerEnter2D( Collider2D collision ) {

            if ( collision.CompareTag( ListTags.PLAYER ) ) {

                gameObject.SetActive( false );
                gameManager.FinishGame( GameResults.WIN );
            }
        }
    }
}