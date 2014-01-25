using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Controller))]
public class Walking : Moving
{
    public float MaxSpeed = 10;
    public float MaxSpeedDeceleration = 300;
    public float GroundAcceleration = 150;
    public float GroundDeceleration = 300;
    public float AirAcceleration = 75;

	public override bool Grounded
	{
		get;
		protected set;
	}

	// component refs:
    private Controller controller;

	// private vars:
    private float direction = 0;
	private int groundedColliderCounter = 0; // counts all ground colliders in contact

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
                Time.deltaTime * controller.Scale * Mathf.Sign(direction) * (grounded ? GroundAcceleration : AirAcceleration));
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
                rigidbody.velocity -= new Vector3(
                    0,
                    0,
                    rigidbody.velocity.z);
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
                rigidbody.velocity += new Vector3(
                    0,
                    0,
					Mathf.Sign(rigidbody.velocity.z) * controller.Scale * MaxSpeed - rigidbody.velocity.z);
            }
        }
    }

	void OnCollisionEnter(Collision collision)
	{
		if (collision.transform.position.y - transform.position.y < 0)
		{
			Grounded = true;
			groundedColliderCounter++;
		}
	}

	void OnCollisionExit(Collision collision)
	{
		if (collision.transform.position.y - transform.position.y < 0)
		{
			if (--groundedColliderCounter == 0)
			{
				Grounded = false;
			}
		}
	}
}
