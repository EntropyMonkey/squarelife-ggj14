using UnityEngine;
using System.Collections;

public class PlayerGroundedHack : MonoBehaviour
{
	PlayerController player;

	// Use this for initialization
	void Awake()
	{
		player = transform.parent.GetComponent(typeof(PlayerController)) as PlayerController;
	}

	void OnTriggerEnter(Collider other)
	{
		player.LandedOn(other);
	}

	void OnTriggerExit(Collider other)
	{
		player.JumpedOff(other);
	}

}
