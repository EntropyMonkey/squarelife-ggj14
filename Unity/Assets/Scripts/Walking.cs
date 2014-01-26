using UnityEngine;
using System.Collections;

public class Walking : Moving
{
    public FloatStat MaxSpeed = 10;
    public FloatStat MaxSpeedDeceleration = 300;
    public FloatStat GroundAcceleration = 150;
    public FloatStat GroundDeceleration = 300;
    public FloatStat AirAcceleration = 75;
    public WorldCollider GroundCollider;

    private Scaling scaling;

    public override bool Grounded
    {
        get
        {
            return GroundCollider.Colliding;
        }
    }

    private float direction = 0;

    void Awake()
    {
        scaling = GetComponent<Scaling>();
    }

    void FixedUpdate()
    {
        //World axes: (camera-axis, up-down, left-right)
        float scale = scaling != null ? scaling.Scale : 1;
        if (direction != 0)
        {
            rigidbody.velocity += Vector3.forward * Mathf.Sign(direction) * Time.deltaTime * scale * (Grounded ? GroundAcceleration : AirAcceleration);
        }
        else if (Grounded)
        {
            if (Mathf.Abs(rigidbody.velocity.z) > Time.deltaTime * scale * GroundDeceleration)
            {
                rigidbody.velocity -= Vector3.forward * Mathf.Sign(rigidbody.velocity.z) * Time.deltaTime * scale * GroundDeceleration;
            }
            else
            {
                rigidbody.velocity -= Vector3.forward * rigidbody.velocity.z;
            }
        }
        if (Mathf.Abs(rigidbody.velocity.z) > scale * MaxSpeed)
        {
            if (Mathf.Abs(rigidbody.velocity.z) > scale * MaxSpeed + Time.deltaTime * scale * MaxSpeedDeceleration)
            {
                rigidbody.velocity -= Vector3.forward * Mathf.Sign(direction) * Time.deltaTime * scale * MaxSpeedDeceleration;
            }
            else
            {
                rigidbody.velocity += Vector3.forward * (Mathf.Sign(rigidbody.velocity.z) * scale * MaxSpeed - rigidbody.velocity.z);
            }
        }
    }

    public override void SetDirection(float direction)
    {
        this.direction = direction;
    }
}
