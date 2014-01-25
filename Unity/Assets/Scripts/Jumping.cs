using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Controller))]
class Jumping : MonoBehaviour
{
	[SerializeField]
    private float MinSpeed = 8;

	[SerializeField]
	private float MaxSpeed = 10;

	[SerializeField]
	private float Gravity = 20;

    private bool jumping = false;

	private Controller controller;

    void Awake()
    {
		controller = GetComponent<Controller>();
    }

    void FixedUpdate()
    {
        if (jumping && controller.Grounded)
        {
            rigidbody.velocity += Vector3.up * Mathf.Lerp(MinSpeed, MaxSpeed, controller.NormalizedAge);
        }
		else
		{
			rigidbody.velocity += Vector3.down * Gravity * Time.deltaTime;
		}
    }
	public void SetJumping(bool jumping)
	{
		this.jumping = jumping;
	}
}
