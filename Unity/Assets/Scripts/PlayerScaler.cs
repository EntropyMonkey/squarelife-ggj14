using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerController))]
public class PlayerScaler : MonoBehaviour
{
	// inspector variables:
	[SerializeField]
	private float maxScale = 20;
    [SerializeField]
    private float lowNormalizedAge = 0;
    [SerializeField]
    private float highNormalizedAge = .8f;
    //Scaling is done so that at lowNorm and below, it is 1, and at highNorm and above, it is maxScale. The development in between is linear.

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
        transform.localScale = Vector3.one * (Scale = Mathf.Lerp(1, maxScale, Mathf.Clamp((playerController.NormalizedAge - lowNormalizedAge) / (highNormalizedAge - lowNormalizedAge), 0, 1)));
	}
}
