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

    
    public Dispatcher<Collider> CollisionBegun = new Dispatcher<Collider>();
    public Dispatcher<Collider> CollisionEnded = new Dispatcher<Collider>();

    private int collisions = 0;

    void OnTriggerEnter(Collider other)
    {
        if (!other.isTrigger && other.transform != transform.parent && other.tag != "Dangerous")
        {
            if (collisions++ == 0)
            {
                CollisionBegun.Dispatch(other);
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
                CollisionEnded.Dispatch(other);
            }
        }
    }
}
