using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class Controllable : MonoBehaviour {
    private const string JUMP = "Jump";

    private Moving moving;
    private Jumping jumping;

    void Awake ()
    {
		moving = GetComponent<Moving>();
        jumping = GetComponent<Jumping>();
    }

    void FixedUpdate()
    {
        moving.SetDirection(Input.GetAxis("Horizontal"));
        jumping.SetJumping(Input.GetButton(JUMP));
    }

}
