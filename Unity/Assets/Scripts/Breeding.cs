using UnityEngine;
using System.Collections;

public class Breeding : MonoBehaviour
{
    public Transform ChildAttachmentPoint;
    public Transform ChildPrefab;
    public Instantiator PlayerPrefabInstantiator;
    public Transform Child { get; private set; }
    public Dispatcher<Transform> SwitchedToChild = new Dispatcher<Transform>();
    public int Hearts = 0;

    private Colored colored;

    public Breeding()
    {
        Child = null;
    }

    void Awake()
    {
        colored = GetComponent<Colored>();
    }

    void OnGUI()
    {
        GUI.TextArea(new Rect(Screen.width - 80, 16, 48, 24), "<3: " + Hearts + "/3");
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
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Partner partner = collision.gameObject.GetComponent<Partner>();
        if (partner != null && Child == null && Hearts >= 3)
        {
            Child = (Transform)Instantiate(ChildPrefab, ChildAttachmentPoint.position, ChildAttachmentPoint.rotation);
            Child.parent = ChildAttachmentPoint;
            Child.GetComponent<Colored>().Color = colored.Blend(partner.Colored);
            partner.Mate(this);
            Hearts -= 3;
        }
    }

}
