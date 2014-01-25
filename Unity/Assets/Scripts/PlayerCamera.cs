using UnityEngine;
using System.Collections;

public class PlayerCamera : MonoBehaviour
{
	[SerializeField]
	private PlayerController player;

	[SerializeField]
	private float minSize = 5;
	[SerializeField]
	private float maxSize = 10;

	[SerializeField]
	private float speed = 2;

	void Awake()
	{
		if (player == null)
			Debug.LogError("Please assign a player to the Main Camera.");
	}

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void FixedUpdate()
	{
		if (player == null)
			return;

		//camera.orthographicSize = minSize + (maxSize - minSize) * player.NormalizedAge;
		camera.fieldOfView = minSize + (maxSize - minSize) * player.NormalizedAge;

		Vector3 newPos = transform.position;
		newPos.z = Mathf.Lerp(newPos.z, player.transform.position.z, speed * Time.deltaTime);
		newPos.y = Mathf.Lerp(newPos.y, player.transform.position.y, speed * Time.deltaTime);
		transform.position = newPos;
	}
}
