using ExampleGame.Characters;
using ExampleGame.GameKernel;
using ExampleGame.UI;
using R3;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace ExampleGame.HealthControllers
{
    public class HealthController : IHealthController, IOnEnable {
        
        private ICharacter character;
        private ICharacterData characterData;

        private readonly ReactiveProperty<int> health = new();
        public Observable<int> Health { get{ return health; } }

        [Inject]
        public void Construct( ICharacter character, ICharacterData characterData, Healthbar uiHealthbar ) {

            this.character = character;
            this.characterData = characterData;

            uiHealthbar.Construct( Health );
        }


        public void InitHealth() {

            health.Value = characterData.Health;
        }

        public void ReduceAllHP() {

            health.Value = 0;
            character.Death();
        }

        public void ReduceHP( int value ) {

            health.Value -= value;

            if ( health.Value <= 0 ) 
                character.Death();
        }

        void IOnEnable.OnEnable() { 
            
            InitHealth(); 
        }
    }
}