using UnityEngine;
using System.Collections;

public class Breeding : MonoBehaviour
{
    public Transform ChildAttachmentPoint;
    public Transform ChildPrefab;
    public Instantiator PlayerPrefabInstantiator;
    public Transform Child { get; private set; }

    public Dispatcher<Transform> SwitchedToChild = new Dispatcher<Transform>();

    private Colored colored;

    public Breeding()
    {
        Child = null;
    }

    void Awake()
    {
        colored = GetComponent<Colored>();
    }

    public void SetSwitching(bool switching)
    {
        if (switching)
        {
            SwitchToChild();
        }
    }

    public void SwitchToChild()
    {
        if (Child != null)
        {
            Transform child = PlayerPrefabInstantiator.Instantiate(Child.position, Child.rotation).transform;
            Colored childColored = child.GetComponent<Colored>();
            childColored.world = colored.world;
            childColored.Color = Child.GetComponent<Colored>().Color;
            SwitchedToChild.Dispatch(child);
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
                    Child.GetComponent<Colored>().Color = colored.Blend(partner.Colored);
                    partner.Mate(this);
                    break;
                }
            }
        }
    }

}
