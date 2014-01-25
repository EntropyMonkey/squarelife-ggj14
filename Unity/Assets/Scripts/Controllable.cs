using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class Controllable : MonoBehaviour {
    private const string JUMP = "Jump";

    private Moving moving;
  //  private Jumping jumping;

    public void Awake ()
    {
		moving = GetComponent(typeof(Moving)) as Moving;
        //jumping = GetComponent<Jumping>();
    }

    public void FixedUpdate()
    {
        moving.SetDirection(Input.GetAxis("Horizontal"));
        jumping.SetJumping(Input.GetButton(JUMP));
    }

}
