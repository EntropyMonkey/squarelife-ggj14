using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour
{
    private const string HORIZONTAL = "Horizontal";
    private const string JUMP = "Jump";
    private const string SWITCH = "Switch";

	PlayerController playerController;

    void Awake ()
    {
		playerController = GetComponent<PlayerController>();
    }

    void FixedUpdate()
    {
		playerController.MoveHorizontal(Input.GetAxis(HORIZONTAL));
        playerController.Jump(Input.GetButtonDown(JUMP));
		playerController.Die(Input.GetButtonDown(SWITCH));
    }

}
