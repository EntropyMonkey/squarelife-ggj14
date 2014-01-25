using UnityEngine;
using System.Collections;

/// <summary>
/// The Player's logic - input
/// </summary>

[RequireComponent(typeof(Female))]
[RequireComponent(typeof(Jumping))]
[RequireComponent(typeof(Mortal))]
[RequireComponent(typeof(Moving))]
public class PlayerController : Controller
{
    public float Age = 0;
	public float Lifetime = 30;

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

    public PlayerController()
    {
        NormalizedAge = Age = 0;
    }

	// component refs:

	private Moving moving;
	private Jumping jumping;
    private Female female;
    private Mortal mortal;

	void Awake()
	{
		moving = GetComponent<Moving>();
		jumping = GetComponent<Jumping>();
        female = GetComponent<Female>();
        mortal = GetComponent<Mortal>();
	}

	// Use this for initialization
	void Start()
	{
        DeathManager.Instance().Player = mortal;
	}

	// Update is called once per frame
	void Update()
	{
        Age = Mathf.Min(Age + Time.deltaTime, Lifetime);
		NormalizedAge = Age / Lifetime;
	}

	public override void MoveHorizontal(float axisValue)
	{
		moving.SetDirection(axisValue);
	}

	public override void Jump(bool jump)
	{
		jumping.SetJumping(jump);
	}
	public void StandingOnCollider(Collider other)
	{
		moving.Grounded = true;
	}

	public void JumpedOff(Collider other)
	{
		moving.Grounded = false;
	}

    public override void Die(bool die)
    {
        if (die)
        {
            female.SwitchToChild();
            mortal.Kill(this);
        }
    }
}
