using UnityEngine;
using System.Collections;

namespace Assets.Scripts
{
    class Jumping : MonoBehaviour
    {
        public float Speed = 8;

        private bool jumping = false;
        private Moving moving;

        public void SetJumping(bool jumping)
        {
            this.jumping = jumping;
        }

        public void Awake()
        {
            moving = GetComponent<Moving>();
        }

        public void FixedUpdate()
        {
            if (jumping && moving.Grounded)
            {
                rigidbody.velocity += new Vector3(
                    0,
                    Speed,
                    0);
            }
        }
    }
}
