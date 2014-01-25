using UnityEngine;
using System.Collections;

namespace Assets.Scripts
{
    class Walking : Moving
    {
        private const float GROUND_DISTANCE_TOLERANCE = .01f;
        private const float GROUND_SPEED_TOLERANCE = .01f;

        public float MaxSpeed = 10;
        public float MaxSpeedDeceleration = 2;
        public float GroundAcceleration = 1;
        public float AirAcceleration = 0.1f;
        public bool Grounded
        {
            get
            {
                return Mathf.Abs(rigidbody.velocity.y) <= GROUND_SPEED_TOLERANCE || Physics.Raycast(transform.position, -Vector3.up, collider.bounds.extents.y + GROUND_DISTANCE_TOLERANCE);
            }
        }

        private Vector2 direction = Vector2.zero;

        public override void SetDirection(Vector2 direction)
        {
            this.direction = direction;
        }

        public void FixedUpdate()
        {
            //World axes: (camera-axis, up-down, left-right)
            bool grounded = Grounded;
            if (direction != Vector2.zero)
            {
                Vector2 delta = Time.deltaTime * (grounded ? GroundAcceleration : AirAcceleration) * direction;
                rigidbody.velocity += new Vector3(0, delta.y, delta.x);
                direction = Vector2.zero;
            }
            else if (grounded)
            {
                if (Mathf.Abs(rigidbody.velocity.z) > Time.deltaTime * GroundAcceleration)
                {
                    rigidbody.velocity = new Vector3(
                        rigidbody.velocity.x,
                        rigidbody.velocity.y,
                        rigidbody.velocity.z - Mathf.Sign(rigidbody.velocity.z) * Time.deltaTime * GroundAcceleration);
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
                    rigidbody.velocity = new Vector3(
                        rigidbody.velocity.x,
                        rigidbody.velocity.y,
                        rigidbody.velocity.z - Mathf.Sign(rigidbody.velocity.z) * Time.deltaTime * MaxSpeedDeceleration);
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
