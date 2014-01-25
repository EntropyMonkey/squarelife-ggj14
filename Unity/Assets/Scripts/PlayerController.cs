using UnityEngine;
using System.Collections;

/// <summary>
/// The Player's logic - input
/// </summary>

[RequireComponent(typeof(Moving), typeof(Jumping))]
public class PlayerController : Controller
{
	// editor variables:

	/// <summary>
	/// Max age in seconds
	/// </summary>
	[SerializeField]
	private float maxAge;

	// publics:

	/// <summary>
	/// the player's current normalized age (0..1)
	/// </summary>
	public override float NormalizedAge
	{
		get;
		protected set;
	}

	public override bool Grounded
	{
		get { return moving.Grounded; }
	}

	// component refs:

	private Moving moving;
	private Jumping jumping;
    private Female female;

	void Awake()
	{
		moving = GetComponent<Moving>();
		jumping = GetComponent<Jumping>();
        female = GetComponent<Female>();
	}

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		NormalizedAge += Time.deltaTime / maxAge;
	}

	public override void MoveHorizontal(float axisValue)
	{
		moving.SetDirection(axisValue);
	}

	public override void Jump(bool jump)
	{
		jumping.SetJumping(jump);
	}
	public void LandedOn(Collider other)
	{
		moving.Grounded = true;
	}

	public void JumpedOff(Collider other)
	{
		moving.Grounded = false;
	}

    public override void Die(bool die)
    {
        if (die && female != null)
        {
            female.SwitchToChild();
        }
    }
}
