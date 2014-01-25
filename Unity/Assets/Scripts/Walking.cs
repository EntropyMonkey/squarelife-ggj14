using UnityEngine;
using System.Collections;

namespace Assets.Scripts
{
    class Walking : Moving
    {
        private const float GROUND_DISTANCE_TOLERANCE = 0.2f;

        public float MaxSpeed = 10;
        public float MaxSpeedDeceleration = 300;
        public float GroundAcceleration = 150;
        public float GroundDeceleration = 300;
        public float AirAcceleration = 75;
        public override bool Grounded
        {
            get
            {
                return Physics.Raycast(transform.position + Vector3.up * GROUND_DISTANCE_TOLERANCE * 0.5f, -Vector3.up, GROUND_DISTANCE_TOLERANCE);
            }
        }

        private PlayerScaler scaler;

        private float direction = 0;

        public override void SetDirection(float direction)
        {
            this.direction = direction;
        }

        void Awake()
        {
            scaler = GetComponent<PlayerScaler>();
        }

        void FixedUpdate()
        {
            //World axes: (camera-axis, up-down, left-right)
            bool grounded = Grounded;
            float scale = scaler != null ? scaler.Scale : 1;
            if (direction != 0)
            {
                rigidbody.velocity += new Vector3(
                    0,
                    0,
                    Time.deltaTime * scale * (grounded ? GroundAcceleration : AirAcceleration) * direction);
            }
            else if (grounded)
            {
                if (Mathf.Abs(rigidbody.velocity.z) > Time.deltaTime * scale * GroundDeceleration)
                {
                    rigidbody.velocity -= new Vector3(
                        0,
                        0,
                        Mathf.Sign(rigidbody.velocity.z) * Time.deltaTime * scale * GroundDeceleration);
                }
                else
                {
                    rigidbody.velocity = new Vector3(
                        rigidbody.velocity.x,
                        rigidbody.velocity.y,
                        0);
                }
            }
            if (Mathf.Abs(rigidbody.velocity.z) > scale * MaxSpeed)
            {
                if (rigidbody.velocity.z > MaxSpeed + Time.deltaTime * scale * MaxSpeedDeceleration)
                {
                    rigidbody.velocity -= new Vector3(
                        0,
                        0,
                        Mathf.Sign(rigidbody.velocity.z) * Time.deltaTime * scale * MaxSpeedDeceleration);
                }
                else
                {
                    rigidbody.velocity = new Vector3(
                        rigidbody.velocity.x,
                        rigidbody.velocity.y,
                        Mathf.Sign(rigidbody.velocity.z) * scale * MaxSpeed);
                }
            }
        }
    }
}
