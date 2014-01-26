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
    public Dispatcher<Collider> CollisionBegun = new Dispatcher<Collider>();
    public Dispatcher<Collider> CollisionEnded = new Dispatcher<Collider>();

    private int collisions = 0;

    void OnTriggerEnter(Collider other)
    {
        if (!other.isTrigger && other.transform != transform.parent)
        {
            if (collisions++ == 0)
            {
                CollisionBegun.Dispatch(other);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (!other.isTrigger && other.transform != transform.parent)
        {
            if (--collisions == 0)
            {
                CollisionEnded.Dispatch(other);
            }
        }
    }
}
