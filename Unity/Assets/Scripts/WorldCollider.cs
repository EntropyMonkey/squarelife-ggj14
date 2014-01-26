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
    public Dispatcher<WorldCollider> CollisionBegun = new Dispatcher<WorldCollider>();
    public Dispatcher<WorldCollider> CollisionEnded = new Dispatcher<WorldCollider>();

    private int collisions = 0;

    void OnTriggerEnter(Collider other)
    {
        if (!other.isTrigger && other.transform != transform.parent)
        {
            if (collisions++ == 0)
            {
                CollisionBegun.Dispatch(this);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (!other.isTrigger && other.transform != transform.parent)
        {
            if (--collisions == 0)
            {
                CollisionEnded.Dispatch(this);
            }
        }
    }
}
