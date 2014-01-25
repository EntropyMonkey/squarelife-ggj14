using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Controller))]
public class Walking : Moving
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

    private Controller controller;

    private float direction = 0;

    public override void SetDirection(float direction)
    {
        this.direction = direction;
    }

    void Awake()
    {
		controller = GetComponent(typeof(Controller)) as Controller;
    }

    void FixedUpdate()
    {
        //World axes: (camera-axis, up-down, left-right)
        bool grounded = Grounded;
        if (direction != 0)
        {
            rigidbody.velocity += new Vector3(
                0,
                0,
                Time.deltaTime * controller.Scale * (grounded ? GroundAcceleration : AirAcceleration) * Mathf.Sign(direction));
        }
        else if (grounded)
        {
			if (Mathf.Abs(rigidbody.velocity.z) > Time.deltaTime * controller.Scale * GroundDeceleration)
            {
                rigidbody.velocity -= new Vector3(
                    0,
                    0,
					Mathf.Sign(rigidbody.velocity.z) * Time.deltaTime * controller.Scale * GroundDeceleration);
            }
            else
            {
                rigidbody.velocity = new Vector3(
                    rigidbody.velocity.x,
                    rigidbody.velocity.y,
                    0);
            }
        }
		if (Mathf.Abs(rigidbody.velocity.z) > controller.Scale * MaxSpeed)
        {
			if (rigidbody.velocity.z > MaxSpeed + Time.deltaTime * controller.Scale * MaxSpeedDeceleration)
            {
                rigidbody.velocity -= new Vector3(
                    0,
                    0,
					Mathf.Sign(rigidbody.velocity.z) * Time.deltaTime * controller.Scale * MaxSpeedDeceleration);
            }
            else
            {
                rigidbody.velocity = new Vector3(
                    rigidbody.velocity.x,
                    rigidbody.velocity.y,
					Mathf.Sign(rigidbody.velocity.z) * controller.Scale * MaxSpeed);
            }
        }
    }
}
