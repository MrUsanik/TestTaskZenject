using ExampleGame.Characters;
using ExampleGame.GameKernel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace ExampleGame.Camera
{
    public class CameraFollower : IPlayingLateTickable
    {
        private readonly ICharacter character;
        private readonly UnityEngine.Camera camera;
        private readonly Vector3 offsetCamera;

        public CameraFollower( ICharacter character, UnityEngine.Camera camera, Vector3 offsetCamera ) {

            this.character = character;
            this.camera = camera;
            this.offsetCamera = offsetCamera;
        }

        void IPlayingLateTickable.LateTick() {

            camera.transform.position = character.GetPosition() + offsetCamera;
        }
    }
}