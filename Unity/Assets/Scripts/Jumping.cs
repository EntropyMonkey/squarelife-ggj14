using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Moving))]
class Jumping : MonoBehaviour
{
    public float Speed = 8;

    private const float TIMEOUT = .1f;

    private bool jumping = false;
    private float timeout = 0;
    private Moving moving;
    private Scaling scaling;

    void Awake()
    {
        moving = GetComponent<Moving>();
        scaling = GetComponent<Scaling>();
    }

    void FixedUpdate()
    {
        float scale = scaling != null ? scaling.Scale : 1;
        if (!moving.Grounded)
        {
            timeout = 0;
        }
        else if (timeout != 0)
        {
            timeout = Mathf.Max(timeout - Time.deltaTime, 0);
        }
        if (jumping && timeout == 0 && moving.Grounded)
        {
            rigidbody.velocity += Vector3.up * scale * Speed;
            timeout = TIMEOUT;
        }
    }

	public void SetJumping(bool jumping)
	{
		this.jumping = jumping;
	}
}
