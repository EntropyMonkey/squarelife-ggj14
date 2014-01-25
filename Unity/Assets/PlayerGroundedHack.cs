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

	void OnTriggerStay(Collider other)
	{
		if (other.name != "Player")
			player.StandingOnCollider(other);
	}

	void OnTriggerExit(Collider other)
	{
		player.JumpedOff(other);
	}
}
