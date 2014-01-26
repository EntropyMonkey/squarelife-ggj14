/*using UnityEngine;
using System.Collections;

public class SpiderController : Controller
{
	[SerializeField]
	private int NumFeet = 6;
	[SerializeField]
	private GameObject FootPrefab;
	[SerializeField]
	private float footRadius = 2;

	[SerializeField]
	private float attackDistance = 10;

	public override bool Grounded
	{
		get { return true; }
	}

	public override float NormalizedAge
	{
		get
		{
			return 1;
		}
		protected set
		{
		}
	}

	GameObject[] feet;

	PlayerController player;

	float jumpTimer;

	void Awake()
	{
		feet = new GameObject[NumFeet];

		float currentAngle = 0;
		float angleStep = Mathf.PI * 2 / NumFeet;
		Vector3 pos;

		for (int i = 0; i < NumFeet; i++)
		{
			pos.z = transform.position.z + footRadius * Mathf.Cos(currentAngle);
			pos.y = transform.position.y + footRadius * Mathf.Sin(currentAngle);
			pos.x = 0;

			currentAngle += angleStep;

			feet[i] = Instantiate(FootPrefab, pos, Quaternion.identity) as GameObject;
			feet[i].transform.parent = transform;
			FixedJoint joint = gameObject.AddComponent(typeof(FixedJoint)) as FixedJoint;
			joint.connectedBody = feet[i].rigidbody;
		}

		player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
	}

	// Use this for initialization
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{
		if (player)
		{
			Vector3 distance = player.transform.position - transform.position;
			if (distance.magnitude < attackDistance)
			{
				MoveHorizontal(distance.normalized.z);
			}
		}
		else
		{
			jumpTimer += Time.deltaTime;
			if (jumpTimer > 4)
			{
				jumpTimer = 0;
				Jump(true);
			}
		}

		if (Input.GetKey(KeyCode.Z))
			Die(true);
	}

	public override void MoveHorizontal(float axisValue)
	{
		rigidbody.AddTorque(Vector3.right * axisValue, ForceMode.Impulse);
	}

	public override void Jump(bool jump)
	{
		if (jump)
			rigidbody.AddForce(Vector3.up * 10, ForceMode.Impulse);
	}

	public override void Die(bool die)
	{
		int i = 0;
		foreach (FixedJoint joint in GetComponents<FixedJoint>())
		{
			feet[i].rigidbody.useGravity = true;
			joint.breakForce = 0;
			i++;
		}
	}
}
*/