using UnityEngine;
using System.Collections;

public class Controllable : MonoBehaviour
{
    private const string HORIZONTAL = "Horizontal";
    private const string JUMP = "Jump";
    private const string SWITCH = "Switch";

    private Breeding breeding;
    private Jumping jumping;
    private Moving moving;

	void Awake()
    {
        breeding = GetComponent<Breeding>();
        jumping = GetComponent<Jumping>();
        moving = GetComponent<Moving>();
	}

	void FixedUpdate()
	{
        if (moving != null)
        {
            moving.SetDirection(Input.GetAxis(HORIZONTAL));
        }
        if (jumping != null)
        {
            jumping.SetJumping(Input.GetButton(JUMP));
        }
        if (breeding != null)
        {
            breeding.SetSwitching(Input.GetButton(SWITCH));
        }
	}
}
