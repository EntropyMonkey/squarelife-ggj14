using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerController))]
public class PlayerScaler : MonoBehaviour
{
	// inspector variables:
	[SerializeField]
	private float maxScale = 20;

	// public variables:
	/// <summary>
	/// The player's current scale
	/// </summary>
	public float Scale
	{
		get;
		private set;
	}

	// component refs:
	private PlayerController playerController;

	void Awake()
	{
		playerController = GetComponent(typeof(PlayerController)) as PlayerController;
	}

	// Use this for initialization
	void Start()
	{
		Scale = 1;
	}

	// Update is called once per frame
	void Update()
	{
		ScaleMe(1 + maxScale * playerController.NormalizedAge);
	}

	void ScaleMe (float newScale)
	{
		newScale = Mathf.Min(newScale, maxScale);
		newScale = Mathf.Max(newScale, 1);

		Scale = newScale;

		transform.localScale = Vector3.one * Scale;
	}
}
