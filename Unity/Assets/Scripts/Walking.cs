using UnityEngine;
using System.Collections;

public class Walking : Moving
{
    public float LowerMaxSpeed = 8;
    public float LowerMaxSpeedDeceleration = 200;
    public float LowerGroundAcceleration = 130;
    public float LowerGroundDeceleration = 200;
    public float LowerAirAcceleration = 45;
    public float UpperMaxSpeed = 12;
    public float UpperMaxSpeedDeceleration = 300;
    public float UpperGroundAcceleration = 200;
    public float UpperGroundDeceleration = 300;
    public float UpperAirAcceleration = 60;
    public float LowerAge = 0;
    public float UpperAge = .8f;
    public WorldCollider GroundCollider;
    public float MaxSpeed { get; private set; }
    public float MaxSpeedDeceleration { get; private set; }
    public float GroundAcceleration { get; private set; }
    public float GroundDeceleration { get; private set; }
    public float AirAcceleration { get; private set; }

    private Age aging;

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
        aging = GetComponent<Age>();
    }

    void FixedUpdate()
    {
        float clamp = aging != null ? Mathf.Clamp((aging.age - LowerAge) / (UpperAge - LowerAge), 0, 1) : 0;
        MaxSpeed = Mathf.Lerp(LowerMaxSpeed, UpperMaxSpeed, clamp);
        MaxSpeedDeceleration = Mathf.Lerp(LowerMaxSpeedDeceleration, UpperMaxSpeedDeceleration, clamp);
        GroundAcceleration = Mathf.Lerp(LowerGroundAcceleration, UpperGroundAcceleration, clamp);
        GroundDeceleration = Mathf.Lerp(LowerGroundDeceleration, UpperGroundDeceleration, clamp);
        AirAcceleration = Mathf.Lerp(LowerAirAcceleration, UpperAirAcceleration, clamp);
        if (direction != 0)
        {
            rigidbody.velocity += Vector3.forward * Mathf.Sign(direction) * Time.deltaTime * (Grounded ? GroundAcceleration : AirAcceleration);
        }
        else if (Grounded)
        {
            if (Mathf.Abs(rigidbody.velocity.z) > Time.deltaTime * GroundDeceleration)
            {
                rigidbody.velocity -= Vector3.forward * Mathf.Sign(rigidbody.velocity.z) * Time.deltaTime * GroundDeceleration;
            }
            else
            {
                rigidbody.velocity -= Vector3.forward * rigidbody.velocity.z;
            }
        }
        if (Mathf.Abs(rigidbody.velocity.z) > MaxSpeed)
        {
            if (Mathf.Abs(rigidbody.velocity.z) > MaxSpeed + Time.deltaTime * MaxSpeedDeceleration)
            {
                rigidbody.velocity -= Vector3.forward * Mathf.Sign(direction) * Time.deltaTime * MaxSpeedDeceleration;
            }
            else
            {
                rigidbody.velocity += Vector3.forward * (Mathf.Sign(rigidbody.velocity.z) * MaxSpeed - rigidbody.velocity.z);
            }
        }
    }

    public override void SetDirection(float direction)
    {
        this.direction = direction;
    }
}
