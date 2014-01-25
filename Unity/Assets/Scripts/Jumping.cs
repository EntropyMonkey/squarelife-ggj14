using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Controller))]
class Jumping : MonoBehaviour
{
	[SerializeField]
    private float Speed = 8;

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
            rigidbody.velocity += new Vector3(
                0,
                (controller.Scale) * Speed,
                0);
        }
    }
	public void SetJumping(bool jumping)
	{
		this.jumping = jumping;
	}
}
