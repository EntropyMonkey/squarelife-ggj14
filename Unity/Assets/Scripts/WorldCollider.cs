using UnityEngine;
using System.Collections;

public class WorldCollider : MonoBehaviour
{
    public bool Colliding
    {
        get
        {
            return collisions > 0;
        }
    }

	public Vector3 LastCollisionPosition
	{
		get;
		private set;
	}

    public Dispatcher<WorldCollider> CollisionBegun = new Dispatcher<WorldCollider>();
    public Dispatcher<WorldCollider> CollisionEnded = new Dispatcher<WorldCollider>();

    private int collisions = 0;

    void OnTriggerEnter(Collider other)
    {
        if (!other.isTrigger && other.transform != transform.parent && other.tag != "Dangerous")
        {
            if (collisions++ == 0)
            {
                CollisionBegun.Dispatch(this);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
		if (!other.isTrigger && other.transform != transform.parent && other.tag != "Dangerous")
        {
            if (--collisions == 0)
            {
				LastCollisionPosition = transform.parent.position;
                CollisionEnded.Dispatch(this);
            }
        }
    }
}
