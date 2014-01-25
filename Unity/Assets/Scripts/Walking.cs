using UnityEngine;
using System.Collections;

namespace Assets.Scripts
{
    class Walking : Moving
    {
        private const float GROUND_DISTANCE_TOLERANCE = .01f;

        public float MaxSpeed = 10;
        public float MaxSpeedDeceleration = 300;
        public float GroundAcceleration = 150;
        public float GroundDeceleration = 300;
        public float AirAcceleration = 75;
        public override bool Grounded
        {
            get
            {
                return Physics.Raycast(transform.position, -Vector3.up, collider.bounds.extents.y + GROUND_DISTANCE_TOLERANCE);
            }
        }

        private float direction = 0;

        public override void SetDirection(float direction)
        {
            this.direction = direction;
        }

        public void FixedUpdate()
        {
            //World axes: (camera-axis, up-down, left-right)
            bool grounded = Grounded;
            if (direction != 0)
            {
                float delta = Time.deltaTime * (grounded ? GroundAcceleration : AirAcceleration) * direction;
                rigidbody.velocity += new Vector3(
                    0,
                    0,
                    delta);
            }
            else if (grounded)
            {
                if (Mathf.Abs(rigidbody.velocity.z) > Time.deltaTime * GroundDeceleration)
                {
                    rigidbody.velocity -= new Vector3(
                        0,
                        0,
                        Mathf.Sign(rigidbody.velocity.z) * Time.deltaTime * GroundDeceleration);
                }
                else
                {
                    rigidbody.velocity = new Vector3(
                        rigidbody.velocity.x,
                        rigidbody.velocity.y,
                        0);
                }
            }
            if (Mathf.Abs(rigidbody.velocity.z) > MaxSpeed)
            {
                if (rigidbody.velocity.z > MaxSpeed + Time.deltaTime * MaxSpeedDeceleration)
                {
                    rigidbody.velocity -= new Vector3(
                        0,
                        0,
                        Mathf.Sign(rigidbody.velocity.z) * Time.deltaTime * MaxSpeedDeceleration);
                }
                else
                {
                    rigidbody.velocity = new Vector3(
                        rigidbody.velocity.x,
                        rigidbody.velocity.y,
                        Mathf.Sign(rigidbody.velocity.z) * MaxSpeed);
                }
            }
        }
    }
}
