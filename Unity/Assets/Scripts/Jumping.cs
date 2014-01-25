using UnityEngine;
using System.Collections;

namespace Assets.Scripts
{
    class Jumping : MonoBehaviour
    {
        public float Speed = 8;

        private bool jumping = false;
        private Moving moving;
        private PlayerScaler scaler;

        public void SetJumping(bool jumping)
        {
            this.jumping = jumping;
        }

        void Awake()
        {
            moving = GetComponent<Moving>();
            scaler = GetComponent<PlayerScaler>();
        }

        void FixedUpdate()
        {
            if (jumping && moving.Grounded)
            {
                rigidbody.velocity += new Vector3(
                    0,
                    (scaler != null ? scaler.Scale : 1) * Speed,
                    0);
            }
        }
    }
}
