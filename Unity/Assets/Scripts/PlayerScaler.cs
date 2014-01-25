using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerController))]
public class PlayerScaler : MonoBehaviour
{
	// inspector variables:
	[SerializeField]
	private Vector2 maxScale = new Vector2(3, 5);

	[SerializeField]
	private Vector2 minScale = new Vector2(1, 1);

	// public variables:
	/// <summary>
	/// The player's current scale
	/// </summary>
	//public float Scale
	//{
	//	get;
	//	private set;
	//}

	// component refs:
	private PlayerController playerController;

	void Awake()
	{
		playerController = GetComponent(typeof(PlayerController)) as PlayerController;
	}

	// Use this for initialization
	void Start()
	{
		transform.localScale = minScale;
	}

	// Update is called once per frame
	void Update()
	{
		ScaleMe(minScale + (maxScale - minScale) * playerController.NormalizedAge);
	}

	void ScaleMe (Vector2 newScale)
	{
		newScale.x = Mathf.Min(newScale.x, maxScale.x);
		newScale.x = Mathf.Max(newScale.x, minScale.x);

		newScale.y = Mathf.Min(newScale.y, maxScale.y);
		newScale.y = Mathf.Max(newScale.y, minScale.y);

		//Scale = newScale;

		transform.localScale = new Vector3(1, newScale.y, newScale.x);
	}
}
