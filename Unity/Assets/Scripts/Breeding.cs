using UnityEngine;
using System.Collections;

public class Breeding : MonoBehaviour
{
    public Transform ChildAttachmentPoint;
    public Transform ChildPrefab;
    public Instantiator PlayerPrefabInstantiator;
    public Transform Child { get; private set; }

    public Dispatcher<Transform> SwitchedToChild = new Dispatcher<Transform>();

    public Breeding()
    {
        Child = null;
    }

    public void SetSwitching(bool switching)
    {
        SwitchToChild();
    }

    public void SwitchToChild()
    {
        if (Child != null)
        {
            SwitchedToChild.Dispatch(PlayerPrefabInstantiator.Instantiate(Child.position, Child.rotation).transform);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (Child == null)
        {
            foreach (ContactPoint contact in collision.contacts)
            {
                Partner partner = contact.otherCollider.GetComponent<Partner>();
                if (partner != null)
                {
                    Child = (Transform)Instantiate(ChildPrefab, ChildAttachmentPoint.position, ChildAttachmentPoint.rotation);
                    Child.parent = ChildAttachmentPoint;
                    partner.Mate(this);
                    break;
                }
            }
        }
    }

}
