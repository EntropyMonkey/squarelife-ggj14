using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {
    private const string DIE = "Die";
    const string HORIZONTAL = "Horizontal";
    const string VERTICAL = "Vertical";

	PlayerController playerController;

    void Awake ()
    {
		playerController = GetComponent<PlayerController>();
    }

    void FixedUpdate()
    {
		playerController.MoveHorizontal(Input.GetAxis(HORIZONTAL));
        playerController.Jump(Input.GetAxis(VERTICAL) > 0);
		Debug.Log(Input.GetAxis(VERTICAL));
		playerController.Die(Input.GetButton(DIE));
    }

}
