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

        void Awake()
        {
            moving = GetComponent<Moving>();
        }

        void FixedUpdate()
        {
            if (jumping && moving.Grounded)
            {
                rigidbody.velocity += new Vector3(
                    0,
                    Speed,
                    0);

				Debug.Log(1);
            }
        }
    }
}
