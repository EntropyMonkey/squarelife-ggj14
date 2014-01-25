using UnityEngine;
using System.Collections;

namespace Assets.Scripts
{
    abstract class Jumping : MonoBehaviour
    {
        private const float SPEED = 10;

        private bool jumping = false;

        public abstract void SetJumping(bool jumping);

        public void FixedUpdate()
        {
            if (jumping)
            {
                rigidbody.velocity = new Vector3(
                    rigidbody.velocity.x,
                    rigidbody.velocity.y,
                    rigidbody.velocity.z + SPEED);
                jumping = false;
            }
        }
    }
}
