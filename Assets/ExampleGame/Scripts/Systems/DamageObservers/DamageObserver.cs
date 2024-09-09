using ExampleGame.GameKernel;
using ExampleGame.HealthControllers;
using ExampleGame.ObjectsDealDamage;
using R3;
using R3.Triggers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using Zenject;

namespace ExampleGame.DamageObservers
{
    public class DamageObserver : IDamageObserver, IOnEnable, IOnDisable
    {
        private IHealthController healthController;
        private Collider2D characterCollider;

        private readonly CompositeDisposable subscriptionsOnDamage = new();

        [Inject]
        public void Construct( IHealthController healthController, Collider2D characterCollider ) {

            this.healthController = healthController;
            this.characterCollider = characterCollider;
        }

        public void Damage( int damage ) {
            
            healthController.ReduceHP( damage );
        }

        void IOnEnable.OnEnable() { SubscribeOnDamage(); }


        void IOnDisable.OnDisable() { UnsubscribeOnDamage(); }


        private void SubscribeOnDamage() {

            characterCollider
                .OnTriggerEnter2DAsObservable()
                .Where( _ => _.gameObject.layer == Layers.OBJECTS_DEAL_DAMAGE )
                .Subscribe( _ => { OnCollision( _ ); } )
                .AddTo( subscriptionsOnDamage );

            characterCollider
                .OnCollisionEnter2DAsObservable()
                .Where( _ => _.gameObject.layer == Layers.OBJECTS_DEAL_DAMAGE )
                .Subscribe( _ => { OnCollision( _.collider ); } )
                .AddTo( subscriptionsOnDamage );
        }

        

        private void UnsubscribeOnDamage() {

            subscriptionsOnDamage.Dispose();
            subscriptionsOnDamage.Clear();
        }

        private void OnCollision( Collider2D objCollision ) {

            
            if ( objCollision.gameObject.layer != Layers.OBJECTS_DEAL_DAMAGE ) return;


            if ( objCollision.TryGetComponent( out IObjectDealDamage objDealDamage ) ) {

                if ( objDealDamage.KillWithOneTouch )
                    healthController.ReduceAllHP();
                else
                    healthController.ReduceHP( objDealDamage.Damage );

            } else {

                Debug.LogError( 
                    $"An object {objCollision.name} without an IObjectDealDamage interface is located on the {Layers.OBJECTS_DEAL_DAMAGE} layer" 
                );
            }
        }

    }
}