using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class PlayerInput : MonoBehaviour {
    private const string JUMP = "Jump";
	const string HORIZONTAL = "Horizontal";

	PlayerController playerController;

    void Awake ()
    {
		playerController = GetComponent<PlayerController>();
    }

    void FixedUpdate()
    {
		playerController.MoveHorizontal(Input.GetAxis(HORIZONTAL));
		playerController.Jump(Input.GetButton(JUMP));
    }

}
